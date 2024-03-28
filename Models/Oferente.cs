using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppiMinistros.Models
{
    public class Oferente
    {
        [Key]
        [Required(ErrorMessage = "Campo requerido")]
        [RegularExpression("^(0\\d{1}-\\d{4}-\\d{4})$")]
        public string OferenteId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(60, ErrorMessage = "Maximo 60 caracteres"), MinLength(10, ErrorMessage = "Minimo 10 caracteres")]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(1900, 2005, ErrorMessage = "la fecha debe seer mayor a 1930")]
        public int FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [RegularExpression("^(\\d{4}-\\d{4})$", ErrorMessage = "Formato erroneo , ####-####")]
        public String Telefono { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(300), MinLength(10)]
        public String Puesto { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public String Estado { get; set; }
        [ForeignKey("OferenteId")]
        public List<Titulo>? titulos { get; set; } = new List<Titulo>();
        [ForeignKey("OferenteId")]
        public List<Experiencia_trabajo>? list_Experiencia_laboral { get; set; } = new List<Experiencia_trabajo>();


    }
}
