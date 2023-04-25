using System;
using System.Collections.Generic;

namespace ApiDomino.Models;

//clase para definir un Tipo CadenaDomino
//el cual contiene las propiedades que nos interesa almacenar
//en la base de datos despues de crear las cadenas validas
public partial class CadenaDomino
{
    public int IdCadena { get; set; }

    public string? Cadena { get; set; }

    public DateTime? Fecha { get; set; }
}
