using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyDapperAPI.DAL.Models
{
    public class Employee
    {
        [Column("EmployeeId")]
        public Guid EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee Name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Employee Age is a required field.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Employee Position is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Position is 50 characters.")]
        public string Position { get; set; } = null!;

        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
    }
}
