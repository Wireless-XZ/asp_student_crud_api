using asp_student_crud_api.Models;

namespace asp_student_crud_api.Repository
{
    public interface IStudentsRepository
    {
        Task<List<StudentModel>> GetAllStudentsAsync();
        Task<StudentModel> GetStudentByIdAsync(int studendId);
        Task<int> AddStudentAsync(StudentModel studentModel);
        Task UpdateStudentAsync(int studentId, StudentModel studentModel);
        Task DeleteStudentAsync(int studentId);
    }
}
