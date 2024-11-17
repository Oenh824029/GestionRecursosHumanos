using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace GestionRecursosHumanos.Models
{
    public class User
    {
        public int Id { get; set; } // será la llave primaria

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [ValidateNever]
        public string NameUser { get; set; }
    }
}
