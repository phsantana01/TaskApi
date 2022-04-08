using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TaskApi.Models
{
	public class Tarefa
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "O campo descrição não pode estar vazio")]
		public string Descricao { get; set; }
		[Required(ErrorMessage = "O campo data não pode estar vazio")]
		public DateTime Data { get; set; }
		public bool Concluido { get; set; }

	}
}
