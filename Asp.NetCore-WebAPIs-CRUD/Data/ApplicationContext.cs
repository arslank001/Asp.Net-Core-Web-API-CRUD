using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestfulAPIs_Asp.netCore.Models;

namespace RestfulAPIs_Asp.netCore.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<StudentModel> Student { get; set; }
    }
}
