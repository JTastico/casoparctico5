public class ProyectoDTO
{
    public int ProyectoId { get; set; }
    public string NombreProyecto { get; set; }
    public string Objetivos { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFinEstimada { get; set; }
    public string Estado { get; set; }
    public decimal PresupuestoEstimado { get; set; }
    public int PersonaClienteId { get; set; }
    public int ResponsableId { get; set; }
}