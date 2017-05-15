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
    public class InvitacionUsuariosController : Controller
    {
        private endepContext db2 = new endepContext();
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: InvitacionUsuarios
        public ActionResult Index(int? id, string nombre)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre) && (id == null))
                {
                    return RedirectToAction("Index", "Equipoes");
                }

                Persona persona = new Persona();
                var usuario = persona.consultarUsuarioCiudad(User.Identity.GetCiudadResidencia());
                ViewBag.NombreEquipo = nombre;
                ViewBag.Id = id;

                return View(usuario);

            }
            catch (Exception ex) {
                
            }

            return RedirectToAction("Index", "Equipoes");

        }

        public ActionResult EnviarInvitacion(int idEquipo, string idUsuario)
        {

            if ((idEquipo == 0) && (idUsuario == null))
            {
                return RedirectToAction("Index", "Equipoes");
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            var user = users.Find(u => u.Id == idUsuario);

            if (user == null)
            {
                return HttpNotFound();
            }

            Correo(user.Nombres, user.UserName, idEquipo, idUsuario);             

            return View("ConfirmacionEnvio");
        }


        public void Correo(string nombre, string destinatario, int idEquipo, string idUsuario)
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add(destinatario);

            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = "Hola "+ nombre+ " Tienes una invitación";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //mmsg.Bcc.Add("destinatariocopia@servidordominio.com"); //Opcional

            //Cuerpo del Mensaje

            string url = Url.Action("RespuestaJugador", "Mensajeria", new { estado = "Confirmado", idEquipo = idEquipo, usuario = idUsuario});
            string urlEquipo = Url.Action("Details", "Equipoes", new { id = idEquipo});
            

            mmsg.Body = "<h1>Hola " + nombre + " </h1> "+
                " <p>Actualmente tiene una invitación para ser parte de un equipo</p>"+
                " <a href='http://localhost:2720/" + urlEquipo + "' target='_self' title='Confirmar invitación'>Ver perfil equipo</a>" +



            " <a href='http://localhost:2720/" + url+"' target='_self' title='Confirmar invitación'>Clic para Confirmar invitación</a>";
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("endep2017@gmail.com");


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("endep2017@gmail.com", "endep2017*");

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
           
            cliente.Port = 587;
            cliente.EnableSsl = true;            

            cliente.Host = "smtp.gmail.com"; //Para Gmail "smtp.gmail.com";


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
            }
        }


    }
}