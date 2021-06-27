using System.ComponentModel;

namespace ECommerce.Domain.Helpers
{
    public enum EFormatOfPayment: long
    {
        [Description("CC")]
        CreditCard = 1, 
        
        [Description("DC")]
        DebitCard = 2,
        
        [Description("BB")]
        BankingBillet = 3
    }
}
