using AutoMapper;
using ListadeTarefas.Repositorio.Interfaces;
using ListadeTarefas.Services.Interfaces;
using ListaTarefasAPI.DTOS;
using ListaTarefasAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace ListaTarefasWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private ITarefaRepository _tarefaRepository;
        public TarefasController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaDTO>>> GetAll()
        {
            var tarefaDto = await _tarefaRepository.GetAll();
            if (tarefaDto == null)
            {
                return NotFound("Tarefa not found");
            }
            return Ok(tarefaDto);
        }

        [HttpGet("{id}", Name = "GetTarefa")]
        public async Task<ActionResult<TarefaDTO>> Get(int id)
        {
            var tarefaDto = await _tarefaRepository.GetById(id);
            if (tarefaDto == null)
            {
                return NotFound("Tarefa not found");
            }
            return Ok(tarefaDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Tarefa tarefaDto)
        {
            if (tarefaDto == null)
                return BadRequest("Data Invalid");

            await _tarefaRepository.Create(tarefaDto);

            return new CreatedAtRouteResult("GetTarefa",
                new { id = tarefaDto.Id_Tarefa }, tarefaDto);
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] Tarefa tarefaDto)
        {
            if (tarefaDto == null)
                return BadRequest("Data invalid");

            await _tarefaRepository.Update(tarefaDto);

            return Ok(tarefaDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Tarefa>> Delete(int id)
        {
            var tarefaDto = await _tarefaRepository.Delete(id);

            if (tarefaDto == null)
            {
                return NotFound("Tarefa not found");
            }

            await _tarefaRepository.Delete(id);

            return Ok(tarefaDto);
        }

    }
}
