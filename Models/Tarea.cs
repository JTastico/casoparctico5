using System;
using System.Collections.Generic;

namespace Casopractico.Models;

public partial class Tarea
{
    public int TareaId { get; set; }

    public int ProyectoId { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateOnly? FechaLimite { get; set; }

    public string Estado { get; set; } = null!;

    public int? AsignadoAId { get; set; }

    public virtual Usuario? AsignadoA { get; set; }

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();

    public virtual Proyecto Proyecto { get; set; } = null!;
}
