using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using System.Security.Principal;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;

namespace endep.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        #region Propiedades

        public string Nombres { set; get; }
        public string Apellidos { set; get; }
        public int TipoDocumento { set; get; }       
        public string Identificacion { set; get; }        
        public string Sexo { set; get; }
        public DateTime? FechaNacimiento { set; get; }
        public string PaisResidencia { set; get; }
        public string DtoResidencia { set; get; }
        public string CiudadResidencia { set; get; }
        public string Imagen { set; get; } 

        #endregion Propiedades


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
                     
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
            var user = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>().FindById(identity.GetUserId());          
            return (user != null) ? user.Nombres : string.Empty;
        }

        public static string GetApellidos(this IIdentity identity)
        {
            var user = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>().FindById(identity.GetUserId());
            return (user != null) ? user.Apellidos : string.Empty;
        }

        public static string GetDtoResidencia(this IIdentity identity)
        {
            var user = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>().FindById(identity.GetUserId());
            return (user != null) ? user.DtoResidencia : string.Empty;
        }

        public static string GetCiudadResidencia(this IIdentity identity)
        {
            var user = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>().FindById(identity.GetUserId());
            return (user != null) ? user.CiudadResidencia : string.Empty;
        }
    }
}