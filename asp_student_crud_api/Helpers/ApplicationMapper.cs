using asp_student_crud_api.Data;
using asp_student_crud_api.Models;
using AutoMapper;

namespace asp_student_crud_api.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Student, StudentModel>().ReverseMap();
        }
    }
}
