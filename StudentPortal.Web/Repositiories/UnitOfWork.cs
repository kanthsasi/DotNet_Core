using StudentPortal.Web.Database;

namespace StudentPortal.Web.Repositiories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;
        public IStudentRepository StudentRepository;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

       /* public IStudentRepository Students 
        {
            get 
            {
                if (StudentRepository == null)
                {
                    return StudentRepository = new SQLStudentRepository(dbContext);
                }
                return StudentRepository;
            }
        }
       */
        public IStudentRepository Students => new SQLStudentRepository(dbContext);

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
