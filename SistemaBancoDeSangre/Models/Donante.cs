using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBancoDeSangre.Models
{
    public class Donante
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo Nombre Completo es Obligatorio")]
        public string NombreCompleto { get; set; }
        public int Edad { get; set; }
        
        [StringLength(1, MinimumLength = 1, ErrorMessage = "El valor debe ser un solo carácter.")]
        public string Genero { get; set;}
        [Required(ErrorMessage = "El Grupo Sanguineo es Obligatorio")]
        [StringLength(3, MinimumLength = 2, ErrorMessage = "El valor debe tener al menos 2 caracteres")]
        public string GrupoSanguineo { get; set; }
        public string Direccion {  get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Peso { get; set; }
    }
}
