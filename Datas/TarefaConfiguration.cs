using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskApi.Models;

namespace TaskApi.Datas
{
	public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
	{
		public void Configure(EntityTypeBuilder<Tarefa> builder)
		{
			builder.ToTable("tasks");

			builder.Property(t => t.Id)
				.HasColumnName("task_id");

			builder.Property(t => t.Descricao)
				.HasColumnName("description")
				.HasColumnType("varchar(max)")
				.IsRequired();

			builder.Property(t => t.Data)
				.HasColumnName("date")
				.HasColumnType("datetime")
				.HasDefaultValueSql("getdate()")
				.IsRequired();

			builder.Property(t => t.Concluido)
				.HasColumnName("concluided")
				.HasColumnType("bit")
				.HasDefaultValue(0)
				.IsRequired();
		}
	}
}
