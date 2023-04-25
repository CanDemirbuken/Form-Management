using Microsoft.EntityFrameworkCore;
using WA_FormManagement.Core.Domain.Entities;
using WA_FormManagement.Core.Domain.RepositoryContracts;
using WA_FormManagement.Infrastructure.ApplicationDbContext;

namespace WA_FormManagement.Infrastructure.Repositories
{
    public class FormRepository : IFormRepository
    {
        private readonly AppDbContext _context;

        public FormRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Form>> GetAllAsync()
        {
            return await _context.Forms.Include(f => f.ApplicationUser).ToListAsync();
        }

        public async Task<Form> GetByIdAsync(int id)
        {
            return await _context.Forms.FindAsync(id);
        }

        public async Task<Form> AddAsync(Form form)
        {
            await _context.Forms.AddAsync(form);
            await _context.SaveChangesAsync();
            return form;
        }

        public async Task<Form> UpdateAsync(Form form)
        {
            _context.Entry(form).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return form;
        }

        public async Task DeleteAsync(Form form)
        {
            _context.Forms.Remove(form);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Forms.AnyAsync(f => f.Id == id);
        }

        public async Task<List<Form>> GetByFormNameAsync(string formName)
        {
            return await _context.Forms.Where(f => f.FormName == formName).ToListAsync();
        }
    }
}
