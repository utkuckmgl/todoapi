using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Models;

namespace ToDoApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<ToDo> ToDos { get; set; }
        public DbSet<SubToDo> SubToDos { get; set; }
        public DbSet<Statu> Status { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
