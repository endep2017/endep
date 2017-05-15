using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace endep.Models
{
    public class IntegranteEquipo
    {
        [Key]
        public int IntegranteEquipoId { set; get; }
        public string id { set; get; }

        [Required(ErrorMessage = "Ingrese una posición del jugador")]
        [Display(Name = "Posición")]
        public int PosicionId { set; get; }

        public int EquipoId { set; get; }

        //public string CorreoRemite { set; get; }
        //public string CorreoDestino { set; get; }
        //public string Mensaje { set; get; }
        public string Estado { set; get; }

        public virtual Equipo Equipo { set; get; }

        public virtual Posicion Posicion { set; get; }



        
    }
}