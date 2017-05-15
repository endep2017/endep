using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace endep.Models
{
    public class TipoDocumento
    {
        [Key]
        public int DocumentoId { set; get; }
        public string Descripcion { set; get; }
        public virtual ICollection<endep.Models.PruebaPersona> PruebaPersona { set; get; }
        
    }
}