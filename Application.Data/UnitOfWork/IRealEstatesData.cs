using Exam.Data.Repositories;
using Exam.Models;

namespace Exam.Data
{
    public interface IRealEstatesData
    {
        IRepository<Comments> Comments { get; }
        IRepository<RealEstate> RealEstates { get; }
        IRepository<Ratings> Ratings { get; }
        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}