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

        public WebhookController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult LogEvents([FromBody] JObject data)
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
             
            if (data["event_type"]?.ToString() == "voucher_used") 
            {
                var dynamicDataList = new LoggedWebHookData();

                dynamicDataList.Data = data.ToString(Formatting.None);

                _context.LoggedWebHookData.AddRange(dynamicDataList);
                _context.SaveChanges();
            }

            return Ok(data);
        }
    }
}
