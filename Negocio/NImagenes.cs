using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NImagenes
    {
        PandoraContext _DbContext = new PandoraContext();
        Imagen iImagen = new Imagen();

        public List<Imagen> Consultar() => _DbContext.Imagens.ToList();

        public Imagen ConsultarId(int id)
        {
           iImagen =  _DbContext.Imagens.Find(id);

            return iImagen;
        }   








    }
}
