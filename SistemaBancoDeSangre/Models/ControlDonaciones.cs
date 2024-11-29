using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaBancoDeSangre.Models
{
    public class ControlDonaciones
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Donante")]
        public int DonanteId { get; set; }  // Cambié esto para que se guarde el ID del Donante

        [Required]
        [Display(Name = "Centro De Donacion")]
        public int CentroDonacionId { get; set; }  // Cambié esto para que se guarde el ID del Centro de Donación

        [Required]
        [Display(Name = "Fecha de Donacion")]
        [DataType(DataType.Date)]
        
        public DateTime FechaDonacion { get; set; }

        // Relaciones
        public Donante Donante { get; set; }

        [Display(Name = "Nombre Centro Donación")]
        public CentroDonacion CentroDonacion { get; set; }
    }
}
