using WA_FormManagement.Core.Domain.Entities;
using WA_FormManagement.Core.Domain.RepositoryContracts;
using WA_FormManagement.Core.ServiceContracts;

namespace WA_FormManagement.Core.Services
{
    public class FormsService : IFormsService
    {
        private readonly IFormRepository _formRepository;

        public FormsService(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public async Task<Form> GetByIdAsync(int id)
        {
            return await _formRepository.GetByIdAsync(id);
        }

        public async Task<List<Form>> GetAllAsync()
        {
            return await _formRepository.GetAllAsync();
        }

        public async Task<Form> CreateAsync(Form form)
        {
            return await _formRepository.AddAsync(form);
        }

        public async Task<Form> UpdateAsync(Form form)
        {
            return await _formRepository.UpdateAsync(form);
        }

        public async Task DeleteAsync(int id)
        {
            var form = await _formRepository.GetByIdAsync(id);
            await _formRepository.DeleteAsync(form);
        }


        public async Task<List<Form>> GetByFormNameAsync(string formName)
        {
            return await _formRepository.GetByFormNameAsync(formName);
        }
    }
}
