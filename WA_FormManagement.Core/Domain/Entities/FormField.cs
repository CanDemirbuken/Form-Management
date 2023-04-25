using System.ComponentModel.DataAnnotations;

namespace WA_FormManagement.Core.Domain.Entities
{
    public class FormField
    {
        public int Id { get; set; }
        public bool Required { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public string DataType { get; set; }

        [Required]
        public int FormId { get; set; }
        public Form Form { get; set; }
    }
}
