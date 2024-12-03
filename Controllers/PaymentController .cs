using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using Microsoft.AspNetCore.Mvc;
using PersonalizedHealthRX_Api.Models;

[ApiController]
[Route("api/payment")]
public class PaymentController : ControllerBase
{
    [HttpPost("generate-token")]
    public IActionResult GenerateHostedPaymentToken(ShippingInfoModel details)
    {
        // Set the environment to SANDBOX for testing or PRODUCTION for live environment
        ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;


        // Replace with your actual API credentials
        ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType
        {
            name = "4HpNdp68fDz", // Replace with your API Login ID
            ItemElementName = ItemChoiceType.transactionKey,
            Item = "4UQT86q6Dce4n6f3" // Replace with your Transaction Key
        };

        var transactionRequest = new transactionRequestType();

        if (details.prefilldetialsStatues == true)
        {
            var transactionRequestvalue = new transactionRequestType
            {
                // Transaction request setup (Note: No payment information here)
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(), // Payment Type (Authorize and Capture)
                amount = 1261.49m, // Amount to charge
                                 // Do not include payment details here
                billTo = new customerAddressType
                {
                    firstName = details.firstName,
                    lastName = details.lastName,
                    address = details.addressline1,
                    city = details.city,
                    state = details.state,
                    zip = details.zipcode,
                    phoneNumber = details.phoneNumber,
                    country = "USA"
                }
            };
            transactionRequest = transactionRequestvalue;
        }
        else
        {
            var transactionRequestvalue = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(), // Payment Type (Authorize and Capture)
                amount = 10.00m, // Amount to charge
                                 // Do not include payment details here
            };
            transactionRequest = transactionRequestvalue;
        }




        // Hosted Payment Page settings (button text, order options)
        settingType[] settings = new settingType[5];

        settings[0] = new settingType();
        settings[0].settingName = settingNameEnum.hostedPaymentButtonOptions.ToString();
        settings[0].settingValue = "{\"text\": \"Pay Now\"}";

        settings[1] = new settingType();
        settings[1].settingName = settingNameEnum.hostedPaymentOrderOptions.ToString();
        settings[1].settingValue = "{\"show\": false}";

        settings[2] = new settingType();
        settings[2].settingName = settingNameEnum.hostedPaymentStyleOptions.ToString();
        settings[2].settingValue = "{\"bgColor\": \"#DC7844\"}";

        settings[3] = new settingType();
        settings[3].settingName = settingNameEnum.hostedPaymentPaymentOptions.ToString();
        settings[3].settingValue = "{\"cardCodeRequired\": false, \"showCreditCard\": true, \"showBankAccount\": false}";

        settings[4] = new settingType();
        settings[4].settingName = settingNameEnum.hostedPaymentSecurityOptions.ToString();
        settings[4].settingValue = "{\"captcha\": false}";

        //settings[5] = new settingType();
        //settings[5].settingValue = settingNameEnum.
        //var settings = new settingType[]
        //{
        //    new settingType { settingName = "hostedPaymentButtonOptions", settingValue = "{\"text\": \"Pay Now\"}" },
        //    new settingType { settingName = "hostedPaymentOrderOptions", settingValue = "{\"show\": false}" } ,
        //    new settingType { settingName = "hostedPaymentStyleOptions", settingValue = "{\"bgColor\": \"#DC7844\"}" },
        //    new settingType { settingName = "hostedPaymentPaymentOptions", settingValue = "{\"cardCodeRequired\": false, \"showCreditCard\": true, \"showBankAccount\": false}"},
        //    new settingType { settingName = "hostedPaymentSecurityOptions", settingValue = "{\"captcha\": false}"},
        //};

        // Request to generate hosted payment page token (without payment details)
        var request = new getHostedPaymentPageRequest
        {
            transactionRequest = transactionRequest,
            hostedPaymentSettings = settings
           
        };

        var controller = new getHostedPaymentPageController(request);
        controller.Execute();

        // Get the response from Authorize.Net API
        var response = controller.GetApiResponse();

        // Check if the response is successful and return the token
        if (response != null && response.messages.resultCode == messageTypeEnum.Ok)
        {
            Console.WriteLine("Message code : " + response.messages.message[0].code);
            Console.WriteLine("Message text : " + response.messages.message[0].text);
            return Ok(new { token = response.token });
        }
        else
        {
            var errorMessage = response?.messages?.message?[0]?.text ?? "Unknown error";
            Console.WriteLine($"Error Code: {response?.messages?.message?[0]?.code}, Message: {errorMessage}");
            return BadRequest($"Failed to generate token: {errorMessage}");
        }
    }
}
