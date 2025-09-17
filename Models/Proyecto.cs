using System;
using System.Collections.Generic;

namespace Casopractico.Models;

public partial class Proyecto
{
    public int ProyectoId { get; set; }

    public string NombreProyecto { get; set; } = null!;

    public string? Objetivos { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFinEstimada { get; set; }

    public string Estado { get; set; } = null!;

    public decimal? PresupuestoEstimado { get; set; }

    /// <summary>
    /// Referencia directa a la tabla Personas
    /// </summary>
    public int PersonaClienteId { get; set; }

    /// <summary>
    /// FK a la tabla Usuarios para el Project Manager
    /// </summary>
    public int? ResponsableId { get; set; }

    public virtual ICollection<Interaccione> Interacciones { get; set; } = new List<Interaccione>();

    public virtual Persona PersonaCliente { get; set; } = null!;

    public virtual Usuario? Responsable { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
