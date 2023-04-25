using WA_FormManagement.Core.Domain.Entities;

namespace WA_FormManagement.Core.ServiceContracts
{
    public interface IFormFieldsService
    {
        Task<List<FormField>> GetFormFieldsByFormIdAsync(int formId);
    }
}
