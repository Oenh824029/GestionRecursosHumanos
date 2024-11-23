using System.ComponentModel.DataAnnotations;

namespace GestionRecursosHumanos.Models
{
    public class Empleados
    {
        [Key]
        public int IdEmpleados { get; set; }
        [Required]
        public string NombreEmpleado { get; set; }
        [Required]
        public string ApellidoEmpleado { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailEmpleado { get; set; }

        [Required]
        public string TelefonoEmpleado { get; set; }

        [Required]
        public string FechaContratacion { get; set; }

        [Required]
        public float SalarioEmpleado { get; set; }
        public int IdCargo_fk { get; set; }
    }
}
