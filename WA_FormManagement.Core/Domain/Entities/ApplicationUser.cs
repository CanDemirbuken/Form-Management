using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WA_FormManagement.Core.Domain.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual ICollection<Form> Forms { get; set; }
    }
}
