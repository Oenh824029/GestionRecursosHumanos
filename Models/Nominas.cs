using System.ComponentModel.DataAnnotations;

namespace GestionRecursosHumanos.Models
{
    public class Nominas
    {
        [Key]
        public int IdNomina { get; set; }

        [Required]
        public int IdEmpleado_fk { get; set; }
        [Required]
        public string PeriodoInicio { get; set; }
        [Required]
        public string PeriodoFin { get; set; }
        public float TotalPagado { get; set; }
       
    }
}
