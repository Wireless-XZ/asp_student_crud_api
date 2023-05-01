using System.ComponentModel.DataAnnotations;

namespace asp_student_crud_api.Data
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public int Year { get; set; }

        public string Grade { get; set; }

        public int Age { get; set; }
    }
}
