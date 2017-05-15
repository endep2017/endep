using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace endep.Models
{
    public class endepContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public endepContext() : base("name=plantillaContext")
        {
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}

        public virtual DbSet<PruebaPersona> PruebaPersona { get; set; }
        public virtual DbSet<ControlDominio> ControlDominios { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentoes { get; set; }
        public virtual DbSet<Persona.Persona> Personas { get; set; }
        public virtual DbSet<LugarGeografico> LugaresGeograficos { set; get; }
        public virtual DbSet<Equipo> Equipos { set; get; }
        public virtual DbSet<Posicion> Posiciones { set; get; }
        public virtual DbSet<IntegranteEquipo> IntegrantesEquipos { set; get; }
    }
}
