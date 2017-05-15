using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace endep.Models.Persona
{
    public class Jugador : PersonaBuilder
    {
        private endepContext db = new endepContext();
        public override bool addRol(string id)
        {
            try
            {
                ApplicationDbContext db = new ApplicationDbContext();

                //Obtener los usuarios            
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                //Obtener los roles
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

                if (!userManager.IsInRole(id, "Jugador"))
                {
                    userManager.AddToRole(id, "Jugador");
                }
                return true;
            }

            catch (Exception e)
            {
                
            }
            return false;
        }
        //public override bool updatePersona(Persona persona)
        //{
        //    throw new NotImplementedException();
        //}
    }
}