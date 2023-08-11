using Datos.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Completion;
using Negocio;
using Presentacion.Security;

namespace Presentacion.Controllers
{
    public class LoginController : Controller
    {

      
        Nlogin enter = new Nlogin();

        public ActionResult Index() { return View(); }

        [HttpPost]
        public ActionResult Login(IFormCollection form)
        {
            string usuario = Convert.ToString(form["correo"]);
            string contra = Convert.ToString(form["contrasena"]);
            string rol = string.Empty;

            Login login = new Login();
            login.usuario = usuario;
            login.contra = contra;

            Response response = enter.Login(login);


            if (response.Exito == 1)
            {
                HttpContext.Session.SetString("nombre", response.Data.Nombre);
                HttpContext.Session.SetInt32("idUsuario", response.Data.idUsuario);
                HttpContext.Session.SetInt32("rol", response.Data.Rol);

                return RedirectToAction("Index", "ItemCliente");

            }
            else
            {
                ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos");
                return RedirectToAction("Index", "Login");
            }

            

          
           

        }

    }
}
