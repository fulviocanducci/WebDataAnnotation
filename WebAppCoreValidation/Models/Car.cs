using System.ComponentModel.DataAnnotations;
namespace WebAppCoreValidation.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
    }
}
