
﻿using Exam.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data
{
    public class EstatesDbContext : IdentityDbContext<ApplicationUser>
    {
        public EstatesDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static EstatesDbContext Create()
        {
            return new EstatesDbContext();
        }

        public IDbSet<Estate> Estates { get; set; }
        public IDbSet<Comments> Comments { get; set; }
        public IDbSet<Ratings> Ratings { get; set; }

    }
}