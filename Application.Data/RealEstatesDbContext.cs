using Exam.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data
{
    public class RealEstatesDbContext : IdentityDbContext<ApplicationUser>
    {
        public RealEstatesDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static RealEstatesDbContext Create()
        {
            return new RealEstatesDbContext();
        }

        public IDbSet<RealEstate> RealEstates { get; set; }
        public IDbSet<Comments> Comments { get; set; }
        public IDbSet<Ratings> Ratings { get; set; }

    }
}
