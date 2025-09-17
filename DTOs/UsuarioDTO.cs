public class UsuarioDTO
{
    public int UsuarioId { get; set; }
    public int PersonaId { get; set; }
    public int RolId { get; set; }
    public string ContrasenaHash { get; set; } // Omitir en DTO si no debes enviar
    public bool Activo { get; set; }
}