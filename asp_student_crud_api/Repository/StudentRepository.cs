using asp_student_crud_api.Data;
using asp_student_crud_api.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

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

        public async Task<StudentModel> GetStudentByIdAsync(int studentId)
        {
            var student = await _studentDbContext.Students.FindAsync(studentId);
            return _mapper.Map<StudentModel>(student);
        }

        public async Task<int> AddStudentAsync(StudentModel studentModel)
        {
            var student = _mapper.Map<Student>(studentModel);

            _studentDbContext.Students.Add(student);
            await _studentDbContext.SaveChangesAsync();

            return student.Id;
        }

        public async Task UpdateStudentAsync(int studentId, StudentModel studentModel)
        {
            var existingStudent = await _studentDbContext.Students.FindAsync(studentId);

            if (existingStudent != null)
            {
                studentModel.Id = studentId;
                studentModel.CreatedAt = existingStudent.CreatedAt;
                studentModel.UpdatedAt = DateTime.Now;

                _mapper.Map(studentModel, existingStudent);

                _studentDbContext.Students.Update(existingStudent);
                await _studentDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateStudentPatchAsync(int studentId, JsonPatchDocument studentModel)
        {
            var existingStudent = await _studentDbContext.Students.FindAsync(studentId);
            
            if (existingStudent != null) 
            {
                studentModel.ApplyTo(existingStudent);
                existingStudent.UpdatedAt = DateTime.Now;
                await _studentDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            var student = new Student() { Id = studentId };

            _studentDbContext.Students.Remove(student);
            await _studentDbContext.SaveChangesAsync();
        }

    }
}
