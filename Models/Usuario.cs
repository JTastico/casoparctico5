using System;
using System.Collections.Generic;

namespace Casopractico.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public int PersonaId { get; set; }

    public int RolId { get; set; }

    /// <summary>
    /// Contraseña encriptada
    /// </summary>
    public string ContrasenaHash { get; set; } = null!;

    public bool? Activo { get; set; }

    public virtual ICollection<Interaccione> Interacciones { get; set; } = new List<Interaccione>();

    public virtual Persona Persona { get; set; } = null!;

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();

    public virtual Role Rol { get; set; } = null!;

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();

    public virtual ICollection<Proyecto> ProyectosNavigation { get; set; } = new List<Proyecto>();
}
