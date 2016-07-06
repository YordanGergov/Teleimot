using Exam.Data.Repositories;
using Exam.Models;

namespace Exam.Data
{
    public interface IEstatesData
    {
        IRepository<Comments> Comments { get; }
        IRepository<Estate> Estates { get; }
        IRepository<Ratings> Ratings { get; }
        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}