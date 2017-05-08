namespace endep.Models.Persona
{
    public abstract class PersonaBuilder
    {
        #region Atributos

        protected Persona persona;

        #endregion Atributos

        #region Métodos

        public void crearPersona()
        {
            persona = new Persona();

        }

        public Persona getPersona()
        {
            return persona;
        }

        #endregion Métodos

        #region Métodos Abstractos

        public abstract bool addRol(string id);
        //public abstract AspNetUser updatePersona(string id);    

        #endregion Métodos Abstractos
    }
}