using WA_FormManagement.Core.Domain.Entities;

namespace WA_FormManagement.Core.ServiceContracts
{
    public interface IFormsService
    {
        Task<Form> GetByIdAsync(int id);
        Task<List<Form>> GetAllAsync();
        Task<Form> CreateAsync(Form form);
        Task<Form> UpdateAsync(Form form);
        Task DeleteAsync(int id);
        Task<List<Form>> GetByFormNameAsync(string formName);
    }
}
