using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Database;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Repositiories
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SQLStudentRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Student> CreateAsync(Student student)
        {
            await dbContext.AddAsync(student);
           // await dbContext.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteAsync(Guid id)
        {
            var existingStudent = await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStudent == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            dbContext.Students.Remove(existingStudent);
            //await dbContext.SaveChangesAsync();
            return existingStudent;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await dbContext.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(Guid id)
        {
            return await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Student?> UpdateAsync(Guid id, Student student)
        {
            var existingStudent = await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStudent == null)
            {
                throw new KeyNotFoundException("Student not found");
            }
            existingStudent.Name = student.Name;
            existingStudent.Email = student.Email;
            existingStudent.Phone = student.Phone;
            existingStudent.Subscribed = student.Subscribed;

           // await dbContext.SaveChangesAsync();
            return existingStudent;
            
        }
    }
}
