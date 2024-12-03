using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PersonalizedHealthRX_Api.Enum
{
    [Serializable]
    [GeneratedCode("xsd", "4.6.1055.0")]
    [XmlType(Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
    public enum settingNameEnum 
    {
        emailCustomer,
        merchantEmail,
        allowPartialAuth,
        headerEmailReceipt,
        footerEmailReceipt,
        recurringBilling,
        duplicateWindow,
        testRequest,
        hostedProfileReturnUrl,
        hostedProfileReturnUrlText,
        hostedProfilePageBorderVisible,
        hostedProfileIFrameCommunicatorUrl,
        hostedProfileHeadingBgColor,
        hostedProfileValidationMode,
        hostedProfileBillingAddressRequired,
        hostedProfileCardCodeRequired,
        hostedProfileBillingAddressOptions,
        hostedProfileManageOptions,
        hostedPaymentIFrameCommunicatorUrl,
        hostedPaymentButtonOptions,
        hostedPaymentReturnOptions,
        hostedPaymentOrderOptions,
        hostedPaymentPaymentOptions,
        hostedPaymentBillingAddressOptions,
        hostedPaymentShippingAddressOptions,
        hostedPaymentSecurityOptions,
        hostedPaymentCustomerOptions,
        hostedPaymentStyleOptions,
        typeEmailReceipt,
        hostedProfilePaymentOptions,
        hostedProfileSaveButtonText,
        hostedPaymentVisaCheckoutOptions
    }
}
