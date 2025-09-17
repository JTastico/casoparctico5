using System;
using System.Collections.Generic;

namespace Casopractico.Models;

public partial class Interaccione
{
    public int InteraccionId { get; set; }

    public int ProyectoId { get; set; }

    public string Tipo { get; set; } = null!;

    public string Resumen { get; set; } = null!;

    public DateTime Fecha { get; set; }

    /// <summary>
    /// El empleado que participó
    /// </summary>
    public int? UsuarioId { get; set; }

    public virtual Proyecto Proyecto { get; set; } = null!;

    public virtual Usuario? Usuario { get; set; }
}
