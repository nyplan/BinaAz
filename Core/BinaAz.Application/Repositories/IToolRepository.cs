namespace BinaAz.Application.Repositories;

public interface IToolRepository<T>
{
    Task<List<T>> GetAsync();
}