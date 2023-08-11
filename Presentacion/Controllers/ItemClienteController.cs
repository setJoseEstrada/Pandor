using Datos.Models;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using Presentacion.Security;

namespace Presentacion.Controllers
{
    [ValidarUsuario]
    public class ItemClienteController : Controller
    {
        NItemCliente _cliente = new NItemCliente();
        NImagenes imagenes = new NImagenes();
        

        public IActionResult Index()
        {
            int idUsuario = (int)HttpContext.Session.GetInt32("idUsuario");
            string nombreGuardado = HttpContext.Session.GetString("nombre");


            ViewBag.NombreGuardado = nombreGuardado;
            List<ItemCliente> Lista = _cliente.Consultar(idUsuario);

            return View(Lista);
        }



        public IActionResult ConsultarImagen()
        {

            List<Imagen> Limg = imagenes.Consultar();

            IEnumerable<Imagen> model = Limg;

            return PartialView("~/Views/ItemCliente/ConsultarImagen.cshtml", model);
            
        }

        public IActionResult ConsultarImg()

        {
            List<Imagen> Limg = imagenes.Consultar();

            return View(Limg);
        }

          public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(IFormCollection form)
        {
            try
            {
                int idUsuario = (int)HttpContext.Session.GetInt32("idUsuario");
                ViewBag.ImagenId = (int)Convert.ToInt32(form["imagenId"]);

                _cliente.Agregar(ViewBag.ImagenId, idUsuario);
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
        }



    }
}
