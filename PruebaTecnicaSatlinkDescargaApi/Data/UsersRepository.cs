using PruebaTecnicaSatlinkDescargaApi.Data.Models;
using PruebaTecnicaSatlinkDescargaApi.Model;

namespace PruebaTecnicaSatlinkDescargaApi.Data
{
    public class UsersRepository
    {

        public static int GetMaxIdUsuario()
        {
            using (var context = new ContextPruebaTecnicaSatLink())
            {
                if (context.Users.Count() == 0)
                {
                    return 1;
                }
                else
                {
                    return context.Users.Max(z => z.Id) + 1;
                }
            }

        }

        public static void Save(User user)
        {
            using (var context = new ContextPruebaTecnicaSatLink())
            {

                int idusuario = GetMaxIdUsuario();

                Usuario usu = new Usuario
                {
                    Id = idusuario,
                    Name = user.Name,
                    Username = user.Username,
                    Email = user.Email,
                    Street = user.Address.Street,
                    Suite = user.Address.Suite,
                    City = user.Address.City,
                    Zipcode = user.Address.Zipcode,
                    Lat = user.Address.Geo.Lat,
                    Lng = user.Address.Geo.Lng,
                    Phone = user.Phone,
                    Website = user.Website,
                    CompanyName = user.Company.Name,
                    CatchPhrase = user.Company.CatchPhrase,
                    Bs = user.Company.Bs
                };

                context.Users.Add(usu);
                context.SaveChanges();
            };

        }
    }
}
