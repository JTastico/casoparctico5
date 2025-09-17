using System;
using System.Collections.Generic;

namespace Casopractico.Models;

public partial class Gasto
{
    public int GastoId { get; set; }

    public int TareaId { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Monto { get; set; }

    public DateOnly FechaGasto { get; set; }

    public virtual Tarea Tarea { get; set; } = null!;
}
