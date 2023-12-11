using System.ComponentModel.DataAnnotations;

namespace SoftUniBazar.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.CategoryNameMinLength)]
        [MaxLength(DataConstants.CategoryNameMaxLength)]
        public string Name { get; set; }

        public ICollection<Ad> Ads { get; set; } = new HashSet<Ad>();
    }
}
