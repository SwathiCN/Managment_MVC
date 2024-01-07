using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Managment.Models
{
    public class Student
    {
        [Key]
        [DisplayName("StudentId")]
        [Range(1, int.MaxValue, ErrorMessage = "StudentId must be greater than 0.")]
        public int StudentId { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Name field is required.")]
        [DisplayName("StudentName")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Section field is required.")]
        [DisplayName("Section")]
        public string Section { get; set; }

        

    }
}
