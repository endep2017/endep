using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace endep.Models
{
    public partial class ControlDominio
    {
        //public ControlDominio()
        //{
        //    this.Persona = new HashSet<Persona.Persona>();
        //}

        [Key]
        //[Display(Name = "Id")]
        public int DominioId { set; get; }

        //[Required(ErrorMessage = "Ingresar una descripción")]
        //[Display(Name = "Descripción")]
        public string Descripcion { set; get; }

        //[Required(ErrorMessage = "Ingresar el consecutivo asociado")]
        //[Display(Name = "Padre Id")]
        public string PadreId { set; get; }
      
        [Display(Name = "Vigente")]
        public string vigente { set; get; }

        [Display(Name = "Abreviatura")]
        public string Abreviatura { set; get; }

        [Display(Name = "Observacion")]
        public string Observacion { set; get; }             

        //public virtual ICollection<Persona.Persona> Persona { set; get; }

    }
}