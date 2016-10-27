using System.ComponentModel.DataAnnotations;

namespace EcommerceTrackerAPI.Models
{
    public class EmailType
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}