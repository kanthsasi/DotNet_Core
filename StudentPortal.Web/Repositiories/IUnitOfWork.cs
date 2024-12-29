namespace StudentPortal.Web.Repositiories
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }

        Task<int> SaveChangesAsync();
    }
}
