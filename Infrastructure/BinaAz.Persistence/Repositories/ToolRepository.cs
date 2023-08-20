using BinaAz.Application.Repositories;
using BinaAz.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BinaAz.Persistence.Repositories;

public class ToolRepository<T> : IToolRepository<T> where T : class
{
    private readonly BinaAzDbContext _context;

    public ToolRepository(BinaAzDbContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAsync()
        => await _context.Set<T>().ToListAsync();
}