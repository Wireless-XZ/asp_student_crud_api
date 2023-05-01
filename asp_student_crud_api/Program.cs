using asp_student_crud_api.Data;
using asp_student_crud_api.Repository;
using Microsoft.EntityFrameworkCore;

namespace asp_student_crud_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register DbContext
            builder.Services.AddDbContext<StudentDbContext>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("StudentAPIDB")
                    )
                );
            
            // Add Student Repository
            builder.Services.AddTransient<IStudentsRepository, StudentRepository>();

            // Add AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}