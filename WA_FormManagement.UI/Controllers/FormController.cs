using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WA_FormManagement.Core.Domain.Entities;
using WA_FormManagement.Core.ServiceContracts;
using WA_FormManagement.Infrastructure.ApplicationDbContext;
using WA_FormManagement.UI.ViewModels;

namespace WA_FormManagement.UI.Controllers
{
    public class FormController : BaseController
    {
        private readonly IFormsService _formService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;

        public FormController(IFormsService formService, UserManager<ApplicationUser> userManager, AppDbContext context)
        {
            _formService = formService;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var forms = await _formService.GetAllAsync();
            var model = new FormsViewModel { Forms = forms };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddForm(Form model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // mevcut kullanıcının bilgileri alınıyor
            var currentUser = await _userManager.GetUserAsync(User);

            // Form nesnesindeki ApplicationUser özelliğine mevcut kullanıcının bilgileri atanıyor
            model.ApplicationUser = currentUser;

            // Form'un CreatedAt özelliğine DateTime.Now atanıyor
            model.CreatedAt = DateTime.Now;

            // Form nesnesi veritabanına ekleniyor
            _context.Forms.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddFormField(int formId, string name, string dataType, bool required)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var form = _context.Forms.FirstOrDefault(f => f.Id == formId);
            if (form == null)
            {
                return NotFound();
            }

            var field = new FormField
            {
                Name = name,
                DataType = dataType,
                Required = required,
                Form = form
            };

            _context.FormFields.Add(field);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult Search(string query)
        {
            var forms = _context.Forms.Where(f => f.FormName.Contains(query)).ToList();
            var viewModel = new FormsViewModel { Forms = forms };
            return View(viewModel);
        }

    }
}
