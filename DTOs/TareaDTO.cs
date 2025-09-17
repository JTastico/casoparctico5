public class TareaDTO
{
    public int TareaId { get; set; }
    public int ProyectoId { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaLimite { get; set; }
    public string Estado { get; set; }
    public int AsignadoAId { get; set; }
}