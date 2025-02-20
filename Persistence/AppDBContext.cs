using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDBContext(DbContextOptions options) : DbContext(options)
{
   public required DbSet<Activity> Activities { get; set; }
}
