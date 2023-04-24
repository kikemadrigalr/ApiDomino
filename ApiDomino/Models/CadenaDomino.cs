using System;
using System.Collections.Generic;

namespace ApiDomino.Models;

public partial class CadenaDomino
{
    public int IdCadena { get; set; }

    public string? Cadena { get; set; }

    public DateTime? Fecha { get; set; }
}
