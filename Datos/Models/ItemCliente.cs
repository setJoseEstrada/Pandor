using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class ItemCliente
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public string? Serie { get; set; }

    public string? Nombre { get; set; }

    public string? Material { get; set; }

    public string? Clase { get; set; }

    public int? UsuarioId { get; set; }

    public byte[]? Imagen { get; set; }

    public virtual Cliente? Usuario { get; set; }
}
