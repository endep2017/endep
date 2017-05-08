using endep.Models;
using endep.Models.Persona;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace endep.Controllers
{
    public class UsuarioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Usuario
        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            var usersView = new List<Usuario>();
            foreach (var user in users)
            {
                var userView = new Usuario
                {
                    UserId = user.Id,
                    Name = user.UserName,
                    Email = user.Email,
                    Nombres = user.Nombres,
                    Apellidos = user.Apellidos,
                    Identificacion = user.Identificacion
                };
                usersView.Add(userView);
            }
            return View(usersView);           
        }
    }
}