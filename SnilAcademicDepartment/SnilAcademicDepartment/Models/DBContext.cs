using System;
using System.Collections.Generic;
using System.Web;
using System.Data.Entity;

namespace SnilAcademicDepartment.Models
{
    public class DBContext : DbContext
    {
        public DbSet<ModelClass> Model { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}