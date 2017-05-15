using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace endep.Models
{
    public class Equipo
    {
        [Key]
        [Index("Equipo_Index", IsUnique = true)]
        public int EquipoId { set; get; }

        [Required(ErrorMessage = "Ingrese un nombre de equipo")]
        [Display(Name = "Nombre")]
        public string Nombre { set; get; }
       
        [Display(Name = "Usuario Creación")]
        public string UsuarioCrea { set; get; }


        public virtual ICollection<IntegranteEquipo> Equipos { set; get; }       
    }
}