using Casopractico.Models;
using Casopractico.Services.Interfaces;

public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
{
    public PersonaRepository(ConsultoriaDbContext context) : base(context) { }
}