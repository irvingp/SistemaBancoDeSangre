using System.ComponentModel.DataAnnotations;

namespace SistemaBancoDeSangre.Models
{
    public class CentroDonacion
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="Nombre del centro de donación Requerido")]
        public string NombreCentro { get; set; }
        public string Direccion { get; set; }
    }
}
