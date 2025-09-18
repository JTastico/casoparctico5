public class GastoDTO
{
    public int GastoId { get; set; }
    public int TareaId { get; set; }
    public string Descripcion { get; set; }
    public decimal Monto { get; set; }
    public DateOnly FechaGasto { get; set; }
}