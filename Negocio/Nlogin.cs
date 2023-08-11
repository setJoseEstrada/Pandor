using Datos.Entidades;
using Datos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Nlogin 
    {
        Response res = new Response();
        

        PandoraContext _context = new PandoraContext();

        Cliente usuario = new Cliente();
       

        public Response Login (Login login)
        {

                res = new Response();
               
                var usuario = _context.Usuarios.Where(d => d.Usuario1 == login.usuario &&
                d.Contra == login.contra).FirstOrDefault();
            if (usuario == null)
            {
                res.Exito = 0;
                    return res;
            }

                var nombre = usuario.Nombre;
                res.Data = new Data();
                res.Data.Nombre = usuario.Nombre;
                res.Exito = 1;
                res.Data.Rol = (int)usuario.RolId;
                res.Data.idUsuario = (int)usuario.Id;

            

            return res; 
        }

    }
}
