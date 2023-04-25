using System.ComponentModel.DataAnnotations;

namespace WA_FormManagement.Core.Domain.Entities
{
    public class Form
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Form Name is required.")]
        public string FormName { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        public virtual ICollection<FormField>? Fields { get; set; }
    }
}
