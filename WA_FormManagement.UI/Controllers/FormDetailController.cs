using Microsoft.AspNetCore.Mvc;
using WA_FormManagement.Infrastructure.ApplicationDbContext;
using WA_FormManagement.UI.ViewModels;

namespace WA_FormManagement.UI.Controllers
{
    public class FormDetailController : BaseController
    {
        private readonly AppDbContext _context;

        public FormDetailController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int formId)
        {
            var formFields = _context.FormFields.Where(ff => ff.FormId == formId).ToList();
            var formViewModel = new FormsViewModel
            {
                FormFields = formFields
            };
            return View(formViewModel);
        }
    }
}
