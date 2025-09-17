using System;
using System.Collections.Generic;

namespace Casopractico.Models;

public partial class Role
{
    public int RolId { get; set; }

    /// <summary>
    /// Ej: Administrador, Gestor de Proyecto, Consultor
    /// </summary>
    public string NombreRol { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
