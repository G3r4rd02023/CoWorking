using System.ComponentModel.DataAnnotations;

namespace CoWorking.Data.Entities
{
    public class Place
    {
        public int Id { get; set; }

        [Display(Name = "Edificio")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }
    }
}
