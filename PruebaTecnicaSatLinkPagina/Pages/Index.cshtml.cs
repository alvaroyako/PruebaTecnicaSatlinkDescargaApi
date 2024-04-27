using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PruebaTecnicaSatlinkDescargaApi.Data.Models;
using PruebaTecnicaSatLinkPagina.Data;

namespace PruebaTecnicaSatLinkPagina.Pages
{
    public class IndexModel : PageModel
    {
        public List<Usuario> users = new List<Usuario>();

        public void OnGet()
        {
            this.users = UsersRepository.List();
        }

        public JsonResult OnGetDetalles(int userId) 
        {
            Usuario? usuario = UsersRepository.Get(userId);
            return new JsonResult(usuario);      
        }

        public JsonResult OnGetEliminar(int userId) 
        {
            var result = UsersRepository.Delete(userId);
            if (result)
            {
                return new JsonResult(new { success = result, msg = "Usuario eliminado con éxito"});
            }
            return new JsonResult(new { success = result, msg = "No se pudo eliminar al usuario" });
        }

        public JsonResult OnGetEditar(int userId, string userName)
        {
            
            var result = UsersRepository.Edit(userId, userName);
            if (result)
            {
                return new JsonResult(new { success = result, msg = "Usuario editado con éxito" });
            }
            return new JsonResult(new { success = result, msg = "No se pudo editar al usuario" });
        }
    }
}
