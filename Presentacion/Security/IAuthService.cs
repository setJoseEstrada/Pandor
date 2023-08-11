using Datos.Models;

namespace Presentacion.Security
{
    public interface IAuthService
    {

        Usuario Login (string username, string password);

        string ObtenerRol(int usuarioId);

    }
}
