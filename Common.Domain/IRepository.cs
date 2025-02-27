namespace Common.Domain;

public interface IRepository<T, in TCreateDto, in TUpdateDto> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();                   
    Task<T> GetByIdAsync(Guid id);                        
    Task<T> CreateAsync(TCreateDto dto);                   
    Task<T> UpdateAsync(Guid id, TUpdateDto dto);          
    Task<bool> DeleteAsync(Guid id);                      
}

