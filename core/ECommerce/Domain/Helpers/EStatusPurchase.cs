using System.ComponentModel;
using Microsoft.AspNetCore.Routing.Matching;

namespace ECommerce.Domain.Helpers
{
    public enum EStatusPurchase: long
    {
        [Description("PAID")]
        Paid = 1,
        
        [Description("OPEN")]
        Open = 2,
        
    }
}