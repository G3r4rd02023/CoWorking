using System.ComponentModel.DataAnnotations;

namespace CoWorking.Data.Entities
{
    public class Classroom
    {
        public int Id { get; set; }

        [Display(Name = "Aula")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Disponible")]
        public bool Available { get; set; }

        public Place Place { get; set; }


    }
}
