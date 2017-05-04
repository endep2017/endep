namespace endep.Models.Persona
{
    public class DirectorTecnico //: PersonaBuilder
    {
        //private endepContext db = new endepContext();

        //public override bool addPersona(Persona persona)
        //{
        //    try
        //    {
        //        //Acceder al contexto de identity
        //        ApplicationDbContext db = new ApplicationDbContext();

        //        //Permite obtener los usuarios
        //        var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        //        var user = userManager.FindByName("endep2017@hotmail.com"); //FindByName -> Busca el usuario en la base de datos

        //        if (user == null)
        //        {
        //            user = new ApplicationUser
        //            {
        //                UserName = "endep2017@hotmail.com",
        //                Email = "endep2017@hotmail.com"
        //            };
        //            userManager.Create(user, "endep2017");
        //        }             
        //        return true;
        //    }

        //    catch (Exception e)
        //    {
        //        Console.WriteLine("{0} Exception caught.", e);
        //    }
        //    return false;
        //}

        //public override AspNetUser updatePersona(AspNetUser persona)
        //{
        //    try
        //    {              
        //        IdentityEntities db = new IdentityEntities(); 
        //        if (id != null)
        //        {
        //            AspNetUser persona = db.AspNetUsers.Find(id);

        //            db.Entry(persona).State = EntityState.Modified;
        //            db.SaveChanges();                  

        //            return persona;
        //        } 
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return null;
        //}
        //public override bool addPersona(Persona persona)
        //{
        //    throw new NotImplementedException();
        //}

        //public override AspNetUser updatePersona(string id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}