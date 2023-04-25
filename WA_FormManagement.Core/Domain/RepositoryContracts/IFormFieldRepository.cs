using WA_FormManagement.Core.Domain.Entities;

namespace WA_FormManagement.Core.Domain.RepositoryContracts
{
    public interface IFormFieldRepository
    {
        Task<List<FormField>> GetFormFieldsByFormIdAsync(int formId);
    }
}
