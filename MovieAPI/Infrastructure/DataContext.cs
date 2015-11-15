using Microsoft.AspNet.Identity.EntityFramework;
using MovieAPI.Domain.Models;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieAPI.Infrastructure {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false) {
        }

        public static ApplicationDbContext Create() {
            return new ApplicationDbContext();
        }

        public IDbSet<Movie> Movies { get; set; }
    }
}