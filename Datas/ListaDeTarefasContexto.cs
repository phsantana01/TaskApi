using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskApi.Models;

namespace TaskApi.Datas
{
	public class ListaDeTarefasContexto : DbContext
	{
		public DbSet<Tarefa> Tarefas { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ListOfTasks;Trusted_Connection=true;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new TarefaConfiguration());
		}

	}
}
