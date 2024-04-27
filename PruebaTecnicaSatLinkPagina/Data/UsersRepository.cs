using PruebaTecnicaSatlinkDescargaApi.Data.Models;

namespace PruebaTecnicaSatLinkPagina.Data
{
    public class UsersRepository
    {
        public static List<Usuario> List()
        {
            using (var context = new ContextPruebaTecnicaSatLink())
            {
                return context.Users.ToList();
            }
        }

        public static Usuario? Get(int idUser)
        {
            using (var context = new ContextPruebaTecnicaSatLink())
            {
                return context.Users.Find(idUser);
            }
        }

        public static bool Delete(int idUser) 
        {
            using (var context = new ContextPruebaTecnicaSatLink())
            {   
                bool result = false;
               Usuario user = context.Users.Find(idUser);
                if (user != null) 
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                    result = true;
                }
                return result;
            }
        }

        public static bool Edit(int userId, string username)
        {
            using (var context = new ContextPruebaTecnicaSatLink())
            {
                bool result = false;
                Usuario user = context.Users.Find(userId);
                if (user != null)
                {
                    user.Username = username;
                    context.SaveChanges();
                    result = true;
                }
                return result;
            }
        }
    }
}
