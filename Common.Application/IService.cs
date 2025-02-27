namespace Common.Application;

public interface IService<T, in TCreateDto, in TUpdateDto>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<T> CreateAsync(TCreateDto dto);
    Task<T> UpdateAsync(Guid id, TUpdateDto dto);
    Task<bool> DeleteAsync(Guid id);
}