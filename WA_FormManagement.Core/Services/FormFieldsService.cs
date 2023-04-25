using WA_FormManagement.Core.Domain.Entities;
using WA_FormManagement.Core.Domain.RepositoryContracts;
using WA_FormManagement.Core.ServiceContracts;

namespace WA_FormManagement.Core.Services
{
    public class FormFieldsService : IFormFieldsService
    {
        private readonly IFormFieldRepository _formFieldsRepository;

        public FormFieldsService(IFormFieldRepository formFieldRepository)
        {
            _formFieldsRepository = formFieldRepository;
        }

        public async Task<List<FormField>> GetFormFieldsByFormIdAsync(int formId)
        {
            return await _formFieldsRepository.GetFormFieldsByFormIdAsync(formId);
        }
    }
}
