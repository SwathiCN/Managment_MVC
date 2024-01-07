using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managment.Models
{
    public class MarksDetail
    {
        [Key]
        public int MarksId { get; set; }

        // Foreign key relationships
        //[ForeignKey("Student")]
        //[Range(1, int.MaxValue, ErrorMessage = "StudentId must be greater than 0.")]
        //public int StudentId { get; set; }

        //[ForeignKey("Teacher")]
        //[Range(1, int.MaxValue, ErrorMessage = "TeacherId must be greater than 0.")]
        //public int TeacherId { get; set; }

        //// Navigation properties
        //public Student Student { get; set; }

        //public Teacher Teacher { get; set; }

        [Required(ErrorMessage = "Subject field is required.")]
        [MaxLength(100)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Marks field is required.")]
        [Range(0, 100, ErrorMessage = "Marks must be between 0 and 100.")]
        public int MarksObtained { get; set; }
    }
}
