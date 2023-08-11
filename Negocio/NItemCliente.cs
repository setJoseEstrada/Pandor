using Datos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public class NItemCliente
    {
        PandoraContext _DbContext = new PandoraContext();
        ItemCliente iCliente = new ItemCliente();
        NImagenes _nImagenes = new NImagenes();
        Imagen _iImagen = new Imagen();





        public List<ItemCliente> Consultar(int idUsuario) => _DbContext.ItemClientes.Where(x=>x.UsuarioId == idUsuario).ToList();



        public void Agregar(int iImagen, int idUsuario)
        {
            

            _iImagen = _nImagenes.ConsultarId(iImagen);


            Usuario usuario = new Usuario();
            var UsuarioLogeado = _DbContext.Usuarios.FirstOrDefault(u => u.Id == idUsuario);
            var iIndice = _DbContext.ItemClientes
            .OrderByDescending(e => e.Id)
            .Select(e => e.Id)
            .FirstOrDefault();

            if (UsuarioLogeado != null)
            {
                var nuevoRegistro = new ItemCliente();
            //    nuevoRegistro.Id = iIndice + 1;
                nuevoRegistro.Descripcion = "Generico";
                nuevoRegistro.Serie = "Generico";
                nuevoRegistro.Nombre = _iImagen.Nombre;
                nuevoRegistro.Material = "Generico";
                nuevoRegistro.Clase = "Generico";
                nuevoRegistro.UsuarioId = idUsuario;
                nuevoRegistro.Imagen = _iImagen.Imagen1;


                _DbContext.Add(nuevoRegistro);
                _DbContext.SaveChanges();

            }




        }

    }
}
