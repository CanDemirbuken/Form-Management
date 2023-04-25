using WA_FormManagement.Core.Domain.Entities;

namespace WA_FormManagement.Core.Domain.RepositoryContracts
{
    public interface IFormRepository
    {
        Task<List<Form>> GetAllAsync();
        Task<Form> GetByIdAsync(int id);
        Task<Form> AddAsync(Form form);
        Task<Form> UpdateAsync(Form form);
        Task DeleteAsync(Form form);
        Task<bool> ExistsAsync(int id);
        Task<List<Form>> GetByFormNameAsync(string formName);
    }
}
