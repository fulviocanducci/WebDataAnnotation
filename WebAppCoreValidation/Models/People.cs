using System.ComponentModel.DataAnnotations;
namespace WebAppCoreValidation.Models
{    
    public class People
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o Valor Inicial")]               
        public int ValueInitials { get; set; }

        [Required(ErrorMessage = "Digite o Valor Final")]
        [MoreThan(nameof(ValueInitials), ErrorMessage = "O valor {0} tem que ser maior ou igual do que {1}")]        
        public int ValueEnds { get; set; }
    }
}
