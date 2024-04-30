using System;
using System.Collections.Generic;

namespace PruebaTecnica2.Models;

public partial class Usuariosnegocio
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string NombreNegocio { get; set; } = null!;

    public string Dirección { get; set; } = null!;

    public string Ruc { get; set; } = null!;
}
