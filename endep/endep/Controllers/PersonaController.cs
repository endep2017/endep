using endep.Models;
using endep.Models.Persona;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace endep.Controllers
{
    public class PersonaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
               
        // GET: Persona
        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            var usersView = new List<Persona>();
            foreach (var user in users)
            {
                var userView = new Persona
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


        public ActionResult Roles(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            //Busqueda del usuario
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            var user = users.Find(u => u.Id == userId);

            if (user == null)
            {
                return HttpNotFound();
            }

            //Búsqueda del rol
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var roles = roleManager.Roles.ToList();


            //Crear lista de roles asociados al usuario
            var rolesView = new List<Rol>();      
                
            foreach (var item in user.Roles)
            {
                var rol = roles.Find(r => r.Id == item.RoleId);

                var roleView = new Rol
                {
                    RolId = rol.Id,
                    Name = rol.Name
                };
                rolesView.Add(roleView);
            }                    

            var userView = new Persona
            {
                Email = user.Email,
                Name = user.UserName,
                UserId = user.Id,
                Nombres = user.Nombres,
                Apellidos = user.Apellidos,
                Roles = rolesView
            };
            return View(userView);
        }        

        public ActionResult AddRol(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Busqueda del usuario
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            var user = users.Find(u => u.Id == userId);

            if (user == null)
            {
                return HttpNotFound();
            }

            var userView = new Persona
            {
                Email = user.Email,
                Name = user.UserName,
                UserId = user.Id,
                Nombres = user.Nombres,
                Apellidos = user.Apellidos               
            };

            //Crear una lista de selección
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var list = roleManager.Roles.ToList();
            list.Add(new IdentityRole { Id = "", Name = "[Seleccione un rol...]" });
            list = list.OrderBy(r => r.Name).ToList();
            ViewBag.RoleID = new SelectList(list, "Id", "Name");

            return View(userView);
        }

        [HttpPost]
        public ActionResult AddRol(string userId, FormCollection form)
        {
            var rolId = Request["RoleID"];

            //Busqueda del usuario
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var users = userManager.Users.ToList();
            var user = users.Find(u => u.Id == userId);

            var userView = new Persona
            {
                Email = user.Email,
                Name = user.UserName,
                UserId = user.Id,
                Nombres = user.Nombres,
                Apellidos = user.Apellidos
            };

            if (string.IsNullOrEmpty(rolId))
            {
                ViewBag.Error = "Seleccione un rol";
                                
                //Crear una lista de selección                
                var list = roleManager.Roles.ToList();
                list.Add(new IdentityRole { Id = "", Name = "[Seleccione un rol...]" });
                list = list.OrderBy(r => r.Name).ToList();
                ViewBag.RoleID = new SelectList(list, "Id", "Name");

                return View(userView);
            }

            //Verifica si el rol ya existe

            var roles = roleManager.Roles.ToList();
            var rol = roles.Find(r => r.Id == rolId);

            if (!userManager.IsInRole(userId, rol.Name))
            {
                userManager.AddToRole(userId, rol.Name);
            }


            //Crear lista de roles asociados al usuario
            var rolesView = new List<Rol>();

            foreach (var item in user.Roles)
            {
                rol = roles.Find(r => r.Id == item.RoleId);

                var roleView = new Rol
                {
                    RolId = rol.Id,
                    Name = rol.Name
                };
                rolesView.Add(roleView);
            }

            userView = new Persona
            {
                Email = user.Email,
                Name = user.UserName,
                UserId = user.Id,
                Nombres = user.Nombres,
                Apellidos = user.Apellidos,
                Roles = rolesView
            };
            return View("Roles", userView);
        }

        public ActionResult Delete(string userId, string rolId)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(rolId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Busqueda del usuario
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var user = userManager.Users.ToList().Find(u => u.Id == userId);
            var rol = roleManager.Roles.ToList().Find(r => r.Id == rolId);

            if(userManager.IsInRole(userId, rol.Name))
            {
                userManager.RemoveFromRole(userId, rol.Name);
            }

            return View("Roles", userId);

        }

        //GET: ACTUALIZAR PERFIL        
        public ActionResult updatePerfil()
        {

            //Busqueda del usuario
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            var user = users.Find(u => u.Id == User.Identity.GetUserId());

            if (user == null)
            {
                return HttpNotFound();
            }

            var userView = new Persona
            {               
                Email = user.Email,
                Name = user.UserName,
                UserId = user.Id,
                Nombres = user.Nombres,
                Apellidos = user.Apellidos,
                Identificacion = user.Identificacion,
                Sexo = user.Sexo,
                PaisResidencia = user.PaisResidencia,
                DtoResidencia = user.DtoResidencia,
                CiudadResidencia = user.CiudadResidencia,
                FechaNacimiento = user.FechaNacimiento                
            };

            endepContext datos = new endepContext();                        
            var list = datos.ControlDominios.ToList();
            //list.Add(new ControlDominio { DominioId = 0, Descripcion = "--- Sexo ---", PadreId = "4" });
            var res = from ctr in list where ctr.PadreId == "4" orderby ctr.DominioId ascending select ctr;
            ViewBag.Sexo = new SelectList(res, "Descripcion", "Descripcion", user.Sexo);

           
            var list2 = datos.LugaresGeograficos.ToList();
            list2.Add(new LugarGeografico { LugarId = 0, Descripcion = "--- Seleccione un Pais ---", PadreId = 0 });
            var res2 = from ctr in list2 where ctr.PadreId == 0 orderby ctr.LugarId ascending select ctr;
            ViewData["Pais"] = new SelectList(res2, "LugarId", "Descripcion", user.PaisResidencia);

            var list3 = datos.LugaresGeograficos.ToList();           
            var res3 = from ctr in list3 where ctr.PadreId == Convert.ToInt32(user.PaisResidencia) orderby ctr.LugarId ascending select ctr;
            ViewBag.Departamento = new SelectList(res3, "LugarId", "Descripcion", user.DtoResidencia);

            var list4 = datos.LugaresGeograficos.ToList();
            var res4 = from ctr in list4 where ctr.PadreId == Convert.ToInt32(user.DtoResidencia) orderby ctr.LugarId ascending select ctr;
            ViewBag.Municipio = new SelectList(res4, "LugarId", "Descripcion", user.CiudadResidencia);
            
            return View(userView);
        }

        [HttpPost]
        public ActionResult updatePerfil(Persona persona)
        {
            ViewBag.Mensaje = ""; 

            if (ModelState.IsValid)
            {
                //Busqueda del usuario
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                var users = manager.Users.ToList();
                ApplicationUser user = users.Find(u => u.Id == User.Identity.GetUserId());                           

                if (user == null)
                {
                    return HttpNotFound();
                }

                user.Nombres = persona.Nombres;
                user.Apellidos = persona.Apellidos;
                user.Identificacion = persona.Identificacion;
                user.Sexo = persona.Sexo;
                user.Email = persona.Email;
                user.UserName = persona.Email;
                user.PaisResidencia = Request["Pais"];
                user.DtoResidencia = Request["Departamento"];
                user.CiudadResidencia = Request["Municipio"];
                user.FechaNacimiento = persona.FechaNacimiento;

                IdentityResult result = manager.Update(user);              


                endepContext datos = new endepContext();
                var list = datos.ControlDominios.ToList();
                //list.Add(new ControlDominio { DominioId = 0, Descripcion = "--- Sexo ---", PadreId = "4" });
                var res = from ctr in list where ctr.PadreId == "4" orderby ctr.DominioId ascending select ctr;
                ViewBag.Sexo = new SelectList(res, "Descripcion", "Descripcion", persona.Sexo);

                var list2 = datos.LugaresGeograficos.ToList();
                list2.Add(new LugarGeografico { LugarId = 0, Descripcion = "--- Seleccione un Pais ---", PadreId = 0 });
                var res2 = from ctr in list2 where ctr.PadreId == 0 orderby ctr.LugarId ascending select ctr;
                ViewData["Pais"] = new SelectList(res2, "LugarId", "Descripcion", user.PaisResidencia);

                var list3 = datos.LugaresGeograficos.ToList();
                var res3 = from ctr in list3 where ctr.LugarId == Convert.ToInt32(user.DtoResidencia) orderby ctr.LugarId ascending select ctr;
                ViewBag.Departamento = new SelectList(res3, "LugarId", "Descripcion", user.DtoResidencia);

                var list4 = datos.LugaresGeograficos.ToList();
                var res4 = from ctr in list4 where ctr.LugarId == Convert.ToInt32(user.CiudadResidencia) orderby ctr.LugarId ascending select ctr;
                ViewBag.Municipio = new SelectList(res4, "LugarId", "Descripcion", user.CiudadResidencia);

                ViewBag.Mensaje = " - Perfil actualizado";

                return View("updatePerfil");
            }       


            ViewBag.Mensaje = "- NO se actualizo el perfil";
            return View("updatePerfil");
        }

        //GET
        public ActionResult updatePassword()
        {            
            return View("updatePassword");
        }

        [HttpPost]
        public ActionResult updatePassword(RegisterViewModel persona)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));          

            if (!string.IsNullOrEmpty(persona.ConfirmPassword))
            {
                manager.RemovePassword(User.Identity.GetUserId());

                manager.AddPassword(User.Identity.GetUserId(), persona.Password);

                ViewBag.Mensaje = "Contraseña Actualizada";
                return View("updatePassword");
            }
            ViewBag.Mensaje = "- se produjo un error al actualizar la contraseña";

            return View("updatePassword");
        }

        public JsonResult GetDepartamento(int id)
        {        
            endepContext datos = new endepContext();
            var list = datos.LugaresGeograficos.ToList();
            //list.Add(new ControlDominio { DominioId = 0, Descripcion = "--- Sexo ---", PadreId = "1" });
            var res = from ctr in list where ctr.PadreId == id orderby ctr.LugarId ascending select ctr;
            return Json(new SelectList(res, "LugarId", "Descripcion"));
        }

        public JsonResult GetMunicipios(int id)
        {
            endepContext datos = new endepContext();
            var list = datos.LugaresGeograficos.ToList();
            //list.Add(new ControlDominio { DominioId = 0, Descripcion = "--- Sexo ---", PadreId = "1" });
            var res = from ctr in list where ctr.PadreId == id orderby ctr.LugarId ascending select ctr;
            return Json(new SelectList(res, "LugarId", "Descripcion"));
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}