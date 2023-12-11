using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SoftUniBazar.Data.Models
{
    public class AdBuyer
    {
        [Required]
        public string BuyerId { get; set; }
        public IdentityUser Buyer { get; set; }

        [Required]
        public int AdId { get; set; }
        public Ad Ad { get; set; }
    }
}
