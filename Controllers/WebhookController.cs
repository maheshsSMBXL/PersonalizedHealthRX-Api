using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PersonalizedHealthRX_Api.Data;

namespace PersonalizedHealthRX_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        private readonly IApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly MdIntegrationsTokenService _mdIntegrationTokenService;

        public WebhookController(ApplicationDbContext context, IConfiguration configuration, MdIntegrationsTokenService mdIntegrationTokenService)
        {
            _context = context;
            _configuration = configuration;
            _mdIntegrationTokenService = mdIntegrationTokenService;
        }

        [HttpPost]
        public async Task<IActionResult> LogEventsAsync([FromBody] JObject data)
        {
            if (data == null)
            {
                return BadRequest();
            }
            // Generate a new EntityId for the dynamic data
            //int entityId = new Random().Next(1, 100000); // Replace with a proper unique ID generator

            //var dynamicDataList = data.Properties()
            //    .Select(prop => new LogEvents
            //    {
            //        EntityId = entityId,
            //        Key = prop.Name,
            //        Value = prop.Value.ToString(),
            //        CreatedAt = DateTime.UtcNow
            //    }).ToList();

            var dynamicDataList = new LoggedWebHookData();

            dynamicDataList.Data = data.ToString(Formatting.None);

            _context.LoggedWebHookData.AddRange(dynamicDataList);
            _context.SaveChanges();

            if (data["event_type"]?.ToString() == "voucher_used") 
            {
                var tokenResponse = await _mdIntegrationTokenService.GetTokenAsync();

                string patientId = data["patient_id"]?.ToString();
                var patientDetailsJson = await _mdIntegrationTokenService.GetPatientDetailsAsync(patientId, tokenResponse.access_token);
                //var patientDetails = JsonConvert.DeserializeObject<PatientDetails>(patientDetailsJson);
                return Ok(patientDetailsJson);
            }

            return Ok();
        }
    }
}
