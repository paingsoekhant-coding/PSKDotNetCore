﻿using Microsoft.EntityFrameworkCore;
using PSKDotNetCore.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSKDotNetCore.MVCApp.Db;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    //}
    public DbSet<BlogModel> Blogs { get; set; }
}
