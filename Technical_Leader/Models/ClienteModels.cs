using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Technical_Leader.Models
{
    public class ClienteModels
    {
        public int Id { get; set; }
        [Display(Name ="Nombre")]
        [Required(ErrorMessage ="Ingresar Nombre.")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Apellido.")]
        public string Apellido { get; set; }
        [Display(Name = "Edad")]
        [Required(ErrorMessage = "Ingresar Edad.")]
        public int Edad { get; set; }
        [Display(Name = "FechaNacimiento")]
        [Required(ErrorMessage = "Ingresar Fecha de Nacimiento.")]
        public string FNacimiento { get; set; }
    }
}