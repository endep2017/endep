using endep.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace endep
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //Acceder al contexto de identity
            ApplicationDbContext db = new ApplicationDbContext();
            //Crear roles por defecto al ejecutar el proyecto
            CreateRoles(db);
            //Crear Uusario por defecto al ejecutar el proyecto
            CreateSuperUser(db);
            //Crear permiso al usuario Administrador por defecto al ejecutar el proyecto
            AddPermisoSuperUser(db);
            //Cerrar la base de datos
            db.Dispose();
        }

        #region Métodos

        //Método que permite creaer el usuario administrador
        private void CreateSuperUser(ApplicationDbContext db)
        {
            //Permite obtener los usuarios
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName("endep2017@hotmail.com"); //FindByName -> Busca el usuario en la base de datos

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "endep2017@hotmail.com",
                    Email = "endep2017@hotmail.com"
                };
                userManager.Create(user, "endep2017");
            }
        }

        //Método que pemite crear los roles
        private void CreateRoles(ApplicationDbContext db)
        {
            //Permite manipular los roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            // .RoleExists -> Se usa para saber si e rol existe
            if (!roleManager.RoleExists("Ver"))
            {
                //Create -> Se usa para crear un rol
                roleManager.Create(new IdentityRole("Ver"));
            }

            if (!roleManager.RoleExists("Editar"))
            {
                roleManager.Create(new IdentityRole("Editar"));
            }

            if (!roleManager.RoleExists("Crear"))
            {
                roleManager.Create(new IdentityRole("Crear"));
            }

            if (!roleManager.RoleExists("Eliminar"))
            {
                roleManager.Create(new IdentityRole("Eliminar"));
            }

            if (!roleManager.RoleExists("Jugador"))
            {
                roleManager.Create(new IdentityRole("Jugador"));
            }
        }

        //Método que pemite asigar los roles al usuario
        private void AddPermisoSuperUser(ApplicationDbContext db)
        {
            //Obtener los usuarios            
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            //Obtener los roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var user = userManager.FindByName("endep2017@hotmail.com"); //FindByName -> Busca el usuario en la base de datos

            if (!userManager.IsInRole(user.Id, "Ver"))
            {
                userManager.AddToRole(user.Id, "Ver");
            }

            if (!userManager.IsInRole(user.Id, "Editar"))
            {
                userManager.AddToRole(user.Id, "Editar");
            }

            if (!userManager.IsInRole(user.Id, "Crear"))
            {
                userManager.AddToRole(user.Id, "Crear");
            }

            if (!userManager.IsInRole(user.Id, "Eliminar"))
            {
                userManager.AddToRole(user.Id, "Eliminar");
            }

            if (!userManager.IsInRole(user.Id, "Jugador"))
            {
                userManager.AddToRole(user.Id, "Jugador");
            }

        }

        #endregion Métodos;
    }
}

