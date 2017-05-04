using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace endep.Models.Persona
{
    public class Persona 
    {
        #region     

        public string UserId { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }

        [Required(ErrorMessage = "Debe introducir los nombres")]
        [DisplayName("Nombres")]
        public string Nombres { set; get; }

        [Required(ErrorMessage = "Debe ingresar los apellidos")]
        [DisplayName("Apellidos")]
        public string Apellidos { set; get; }

        [Required(ErrorMessage = "Debe ingresar el número de identificación")]
        [DisplayName("Identificación")]
        public decimal Identificacion { set; get; }

        //[Required(ErrorMessage = "Debe ingresar la fecha de nacimiento")]
        //[DisplayName("Fecha de Nacimiento")]
        //public DateTime FechaNacimiento { set; get; }

        public string Sexo { set; get; }

        public Rol Rol { set; get; }
        public List<Rol> Roles { set; get; }


        #endregion
    }
}