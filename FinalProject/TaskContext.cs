﻿using System.Data.Entity;

namespace FinalProject
{
    public class TaskContext : DbContext
    {
    //user
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
