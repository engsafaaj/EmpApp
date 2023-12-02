using EmpApp.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EmpApp.Data
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conString = @"Server=.\SQLEXPRESS;Database=EmpAppData;Encrypt=False;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(conString);
        }

        // Tables
        public DbSet<EmployeeData> EmployeeData { get; set; }
    }
}
