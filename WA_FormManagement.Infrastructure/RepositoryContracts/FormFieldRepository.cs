using Microsoft.EntityFrameworkCore;
using WA_FormManagement.Core.Domain.Entities;
using WA_FormManagement.Core.Domain.RepositoryContracts;
using WA_FormManagement.Infrastructure.ApplicationDbContext;

namespace WA_FormManagement.Infrastructure.RepositoryContracts
{
    public class FormFieldRepository : IFormFieldRepository
    {
        private readonly AppDbContext _context;

        public FormFieldRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<FormField>> GetFormFieldsByFormIdAsync(int formId)
        {
            return await _context.FormFields.Where(f => f.FormId == formId).ToListAsync();
        }
    }
}
