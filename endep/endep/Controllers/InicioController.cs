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
    [Authorize]
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Index()
        {
            //ApplicationDbContext db = new ApplicationDbContext();

            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            //var users = userManager.Users.ToList();
            //var user = users.Find(u => u.Id == User.Identity.GetUserId());


            //var userView = new Persona
            //{
            //    Email = user.Email,
            //    Name = user.UserName,
            //    UserId = user.Id,
            //    Nombres = user.Nombres,
            //    Apellidos = user.Apellidos
            //};
            //return View(userView);
            return View();        
        }
    }
}