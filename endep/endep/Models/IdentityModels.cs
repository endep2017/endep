using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using System.Security.Principal;

namespace endep.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public string Nombres { set; get; }
        public string Apellidos { set; get; }
        public decimal Identificacion { set; get; }
        //blic DateTime FechaNacimiento { set; get; }
        public string Sexo { set; get; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario

            //Estensiones de identity staticas
            userIdentity.AddClaim(new Claim("Nombres", this.Nombres.ToString()));
            return userIdentity;
        }
        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public static class IdentityExtensions
    {
        public static string GetNombres(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("Nombres");
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}