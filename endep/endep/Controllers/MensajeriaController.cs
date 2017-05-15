using endep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace endep.Controllers
{
    public class MensajeriaController : Controller
    {
        private endepContext db = new endepContext();
        // GET: Mensajeria
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RespuestaJugador(string estado, int idEquipo, string usuario)
        {
            IntegranteEquipo integrante = new IntegranteEquipo();
         

            if (estado == "Confirmado")
            {
                integrante.id = usuario;
                integrante.EquipoId = idEquipo;
                integrante.Estado = estado;
                integrante.PosicionId = 3;
               

                if (ModelState.IsValid)
                {
                    db.IntegrantesEquipos.Add(integrante);
                    db.SaveChanges();                   
                }

            }

            return View();
        }

    }
}