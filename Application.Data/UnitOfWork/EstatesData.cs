using Exam.Data.Repositories;
using Exam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data
{
    public class EstatesData :IEstatesData
    {
        private DbContext context;
        private Dictionary<System.Type, object> repositories;

        public EstatesData(EstatesDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<System.Type, object>();
        }
        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Estate> Estates
        {
            get { return this.GetRepository<Estate>(); }
        }
        public IRepository<Ratings> Ratings
        {
            get { return this.GetRepository<Ratings>(); }
        }

        public IRepository<Comments> Comments
        {
            get { return this.GetRepository<Comments>(); }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}

