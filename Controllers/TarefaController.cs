using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Datas;
using TaskApi.Models;

namespace TaskApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TarefaController : ControllerBase
	{
		[HttpPost("registrarTarefa")]
		public IActionResult RegistrarTarefa([FromBody] Tarefa task)
		{
			using (var contexto = new ListaDeTarefasContexto())
			{
				var tarefa = new Tarefa()
				{
					Descricao = task.Descricao,
					Data = task.Data
				};
				contexto.Tarefas.Add(tarefa);
				contexto.SaveChanges();
				return CreatedAtAction(nameof(ListarTarefaPorId), new { Id = tarefa.Id }, tarefa);
			}
		}

		[HttpGet("recuperarTarefas")]
		public IActionResult ListarTarefas()
		{
			using (var contexto = new ListaDeTarefasContexto())
			{
				var tarefas = contexto.Tarefas.Where(t => t.Concluido == false).ToList().OrderBy(t => t.Data);
				if (tarefas == null)
				{
					return NotFound();
				}
				return Ok(tarefas);
			}
		}

		[HttpGet("recuperarTarefasConcluidas")]
		public IActionResult ListarTarefasConcluidas()
		{
			using (var contexto = new ListaDeTarefasContexto())
			{
				var tarefas = contexto.Tarefas.Where(t => t.Concluido == true).ToList().OrderBy(t => t.Data);
				if (tarefas == null)
				{
					return NotFound();
				}
				return Ok(tarefas);
			}
		}

		[HttpGet("recuperarTarefaPorId/{id}")]
		public IActionResult ListarTarefaPorId(int id)
		{
			using (var contexto = new ListaDeTarefasContexto())
			{
				var tarefa = contexto.Tarefas.Where(t => t.Id == id).FirstOrDefault();
				if (tarefa == null)
				{
					return NotFound();
				}
				return Ok(tarefa);
			}
		}

		[HttpPut("atualizarTarefa/{id}")]
		public IActionResult AtualizarTarefa(int id, [FromBody] Tarefa task)
		{
			using (var contexto = new ListaDeTarefasContexto())
			{
				var tarefa = contexto.Tarefas.Where(t => t.Id == id).FirstOrDefault();
				if (tarefa == null)
				{
					return NotFound();
				}
				tarefa.Descricao = task.Descricao;
				tarefa.Data = task.Data;
				contexto.SaveChanges();
				return NoContent();
			}
		}

		[HttpPut("concluirTarefa/{id}")]
		public IActionResult ConcluirTarefa(int id)
		{
			using (var contexto = new ListaDeTarefasContexto())
			{
				var tarefa = contexto.Tarefas.Where(t => t.Id == id).FirstOrDefault();
				if (tarefa == null)
				{
					return NotFound();
				}
				tarefa.Concluido = true;
				contexto.SaveChanges();
				return NoContent();
			}
		}

		[HttpPut("deixarPendente/{id}")]
		public IActionResult DeixarTarefaPendente(int id)
		{
			using (var contexto = new ListaDeTarefasContexto())
			{
				var tarefa = contexto.Tarefas.Where(t => t.Id == id).FirstOrDefault();
				if (tarefa == null)
				{
					return NotFound();
				}
				tarefa.Concluido = false;
				contexto.SaveChanges();
				return NoContent();
			}
		}

		[HttpDelete("excluirTarefa/{id}")]
		public IActionResult ExcluirTarefa(int id)
		{
			using (var contexto = new ListaDeTarefasContexto())
			{
				var tarefa = contexto.Tarefas.Where(t => t.Id == id).FirstOrDefault();
				if (tarefa == null)  
				{
					return NotFound();
				}
				contexto.Remove(tarefa);
				contexto.SaveChanges();
				return NoContent();
			}
		}






	}
}
