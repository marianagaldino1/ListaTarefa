using ListaTarefasAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ListaTarefasAPI.Configurations
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Tarefa> Tarefas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // adiciona todas as referências que utilizam como extensão a IEntityTypeConfiguration 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());



        }

    }
}