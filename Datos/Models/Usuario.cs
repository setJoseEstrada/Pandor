using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Usuario1 { get; set; }

    public string? Contra { get; set; }

    public string? Nombre { get; set; }

    public int? RolId { get; set; }

    public virtual Role? Rol { get; set; }
}
