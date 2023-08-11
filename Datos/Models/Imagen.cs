using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Imagen
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public byte[]? Imagen1 { get; set; }
}
