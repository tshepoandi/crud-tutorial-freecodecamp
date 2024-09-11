using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TodoAPI.Models;

namespace TodoAPI.AppDataContext;

public class ToDoDbContext : DbContext
{
    private readonly DbSettings _dbsettings;

    public ToDoDbContext(IOptions<DbSettings> dbSettings)
    {
        _dbsettings = dbSettings.Value;   
    }
    public DbSet<ToDo> ToDos {get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_dbsettings.ConnectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDo>().ToTable("ToDoApi").HasKey(x => x.Id);
    }
}