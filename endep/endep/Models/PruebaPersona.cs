using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace endep.Models
{
    public class PruebaPersona
    {
        [Key]
          
        [Display(Name = "Id")]
        public string PesonaId { set; get; }
        [Display(Name = "Nombres")]
        public string Nombres { set; get; }

        [Display(Name = "Apellidos")]
        public string Apellidos { set; get; }

        [Display(Name = "Identificación")]
        public string Identificacion { set; get; }

        public int DocumentoId { set; get; }
        public virtual TipoDocumento TipoDocumento { set; get; }
    }
}