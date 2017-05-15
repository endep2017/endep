using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace endep.Models
{
    public class LugarGeografico
    {
        [Key]
        public int LugarId { set; get; }
        public string Descripcion { set; get; }
        public int PadreId { set; get; }

    }
}