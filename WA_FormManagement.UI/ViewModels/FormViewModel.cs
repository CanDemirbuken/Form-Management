using System.ComponentModel.DataAnnotations;
using WA_FormManagement.Core.Domain.Entities;

namespace WA_FormManagement.UI.ViewModels
{
    public class FormsViewModel
    {
        public List<Form> Forms { get; set; }

        [Required(ErrorMessage = "Form Name is required.")]
        public string FormName { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required]
        public int FormId { get; set; }

        [Required]
        public bool Required { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required]
        public string DataType { get; set; }

        public List<FormField> FormFields { get; set; }
    }

}
