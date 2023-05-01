using System.ComponentModel.DataAnnotations;

namespace asp_student_crud_api.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("(?i)^(male|female)$", ErrorMessage = "Gender must be either 'male' or 'female'.")]
        public string Gender { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Year { get; set; }

        [Required]
        [RegularExpression("(A|B|C|a|b|c)", ErrorMessage = "Grade must be 'A', 'B', or 'C'.")]
        public string Grade { get; set; }

        [Required]
        [Range(16, 40, ErrorMessage = "Age must be between 16 and 40.")]
        public int Age { get; set; }
    }
}
