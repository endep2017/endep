﻿using System;
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
                db.Personas.Add(persona);
                db.SaveChanges();
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            return false;
        }
        //public override bool updatePersona(Persona persona)
        //{
        //    throw new NotImplementedException();
        //}
    }
}