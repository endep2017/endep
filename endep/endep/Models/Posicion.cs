using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace endep.Models
{
    public class Posicion
    {
        public int PosicionId { set; get; }
        public string Nombre { set; get; }

        public virtual ICollection<IntegranteEquipo> IntegrantesEquipos { set; get; }
    }
}