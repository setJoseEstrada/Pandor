using Datos.Models;

namespace Presentacion.Security
{
    public class AuthService: IAuthService
    {
        public AuthService() { }

        PandoraContext _context = new PandoraContext();

        public Role ObtenerRol(int usuarioId)
        {
            var usuario = _context.Set<Usuario>().Find(usuarioId);

            return usuario?.Rol;
        }

        public Usuario Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        string IAuthService.ObtenerRol(int usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}
