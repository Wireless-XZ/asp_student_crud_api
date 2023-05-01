using asp_student_crud_api.Data;
using asp_student_crud_api.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace asp_student_crud_api.Repository
{
    public class StudentRepository : IStudentsRepository
    {
        private readonly StudentDbContext _studentDbContext;
        private readonly IMapper _mapper;

        public StudentRepository(StudentDbContext studentDbContext, IMapper mapper)
        {
            _studentDbContext = studentDbContext;
            _mapper = mapper;
        }
        public async Task<List<StudentModel>> GetAllStudentsAsync()
        {
            var students = await _studentDbContext.Students.ToListAsync();
            return _mapper.Map<List<StudentModel>>(students);
        }

        public async Task<StudentModel> GetStudentByIdAsync(int studendId)
        {
            var student = await _studentDbContext.Students.FindAsync();
            return _mapper.Map<StudentModel>(student);
        }

        public async Task<int> AddStudentAsync(StudentModel studentModel)
        {
            var student = new Student()
            {
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Gender = studentModel.Gender,
                Year = studentModel.Year,
                Age = studentModel.Age,
                Grade = studentModel.Grade
            };

            _studentDbContext.Students.Add(student);
            await _studentDbContext.SaveChangesAsync();

            return student.Id;
        }

        public async Task UpdateStudentAsync(int studentId, StudentModel studentModel)
        {
            var student = new Student()
            {
                Id = studentModel.Id,
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Gender = studentModel.Gender,
                Year = studentModel.Year,
                Age = studentModel.Age,
                Grade = studentModel.Grade
            };

            _studentDbContext.Students.Update(student);
            await _studentDbContext.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            var student = new Student() { Id = studentId };

            _studentDbContext.Students.Remove(student);
            await _studentDbContext.SaveChangesAsync();
        }
    }
}
