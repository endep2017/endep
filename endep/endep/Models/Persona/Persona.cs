using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using endep.Models;


namespace endep.Models.Persona
{
    public class Persona
    {

        #region Atributos

        private endepContext db = new endepContext();
        private ApplicationDbContext dbIdentity = new ApplicationDbContext();

        #endregion Atributos

        #region     
        [Key]
        [Display(Name = "Id")]
        public string UserId { set; get; }

        [Display(Name = "Nombre")]
        public string Name { set; get; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { set; get; }

        [Display(Name = "Nombres")]
        public string Nombres { set; get; }

        [Display(Name = "Apellidos")]
        public string Apellidos { set; get; }


        [Display(Name = "Identificación")]
        public string Identificacion { set; get; }

        [Display(Name = "Sexo")]
        public string Sexo { set; get; }

        [Display(Name = "Fecha Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime? FechaNacimiento { set; get; }

        [Display(Name = "Pais Residencia")]
        public string PaisResidencia { set; get; }

        [Display(Name = "Departarmento Residencia")]
        public string DtoResidencia { set; get; }

        [Display(Name = "Ciudad Residencia")]
        public string CiudadResidencia { set; get; }
        public string Imagen { set; get; }
        public Rol Rol { set; get; }
        public List<Rol> Roles { set; get; }

        [Required(ErrorMessage = "Debe seleccionar un tipo de cedula")]
        [Display(Name = "Tipo de cedula")]
        public int DocumentoId { set; get; }
        //public virtual TipoDocumento TipoDocumento { set; get; }

        //public virtual ControlDominio ControlDominio { set; get; }

        #endregion

        #region Métodos   

        public Object consultarUsuarios()
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
                    Identificacion = user.Identificacion,
                    DtoResidencia = consultarLugarGeografico(user.DtoResidencia),
                    CiudadResidencia = consultarLugarGeografico(user.CiudadResidencia)
                };
                usersView.Add(userView);
            }
            return usersView;
        }

        public Object consultarUsuarioId(string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            var user = users.Find( x => x.Id == id);

            var usersView = new List<Persona>();

            var userView = new Persona
            {
                UserId = user.Id,
                Name = user.UserName,
                Email = user.Email,
                Nombres = user.Nombres,
                Apellidos = user.Apellidos,
                Identificacion = user.Identificacion,
                DtoResidencia = consultarLugarGeografico(user.DtoResidencia),
                CiudadResidencia = consultarLugarGeografico(user.CiudadResidencia)
            };
            usersView.Add(userView);

            return usersView;
        }


        public Object consultarUsuarioCiudad(string idLugar)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbIdentity));
            var users = userManager.Users.ToList();

            var usuarios = from u in users where u.CiudadResidencia == idLugar orderby u.Nombres ascending select u;

            var usersView = new List<Persona>();

            foreach (var user in usuarios)
            {
                var userView = new Persona
                {
                    UserId = user.Id,
                    Name = user.UserName,
                    Email = user.Email,
                    Nombres = user.Nombres,
                    Apellidos = user.Apellidos,
                    Identificacion = user.Identificacion,
                    DtoResidencia = consultarLugarGeografico(user.DtoResidencia),
                    CiudadResidencia = consultarLugarGeografico(user.CiudadResidencia)
                };
                usersView.Add(userView);
            }

            return usersView;
        }

        public string consultarLugarGeografico(string idLugar)
        {
            string dato = "";

            var geografico = db.LugaresGeograficos.ToList();
            var Lugares = from g in geografico where g.LugarId == Convert.ToInt32(idLugar) select g;

            foreach (var lugar in Lugares)
            {
                dato = lugar.Descripcion;
                return dato;
            }

            return dato;
        }



        #endregion Métodos

    }
}