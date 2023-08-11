using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string? Usuario { get; set; }

    public string? Contra { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public int? RolId { get; set; }

    public virtual ICollection<ItemCliente> ItemClientes { get; set; } = new List<ItemCliente>();

    public virtual Role? Rol { get; set; }
}
