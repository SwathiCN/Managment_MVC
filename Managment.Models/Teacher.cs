using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Managment.Models
{
    public class Teacher
    {
        [Key]
        [DisplayName("TeacherId")]
        [Range(1, int.MaxValue, ErrorMessage = "TeacherId must be greater than 0.")]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Name field is required.")]
        [DisplayName("TeacherName")]
        public string TeacherName { get; set; }



    }
}
