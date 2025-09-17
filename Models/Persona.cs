using System;
using System.Collections.Generic;

namespace Casopractico.Models;

public partial class Persona
{
    public int PersonaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    /// <summary>
    /// Diferencia el tipo de persona
    /// </summary>
    public string Tipo { get; set; } = null!;

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();

    public virtual Usuario? Usuario { get; set; }
}
