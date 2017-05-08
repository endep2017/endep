namespace endep.Models.Persona
{
    public class PersonaDirector
    {
        private PersonaBuilder personaBuilder;

        public void setPersonaBuilder(PersonaBuilder persona)
        {
            personaBuilder = persona;
        }

        public Persona getPersona()
        {
            return personaBuilder.getPersona();
        }

        public bool construirRol(string id)
        {
            bool resul = false;

            personaBuilder.crearPersona();
            resul = personaBuilder.addRol(id);

            if (resul)
            {
                return true;
            }
            return false;
        }

        //public Persona actualizarPersona(string id)
        //{
        //    personaBuilder.crearPersona();
        //    var persona = personaBuilder.updatePersona(id);
        //    return persona;
        //}

    }
}