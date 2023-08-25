using AutoMapper;
using ListadeTarefas.Repositorio.Implementação;
using ListadeTarefas.Repositorio.Interfaces;
using ListadeTarefas.Services.Interfaces;
using ListaTarefasAPI.DTOS;
using ListaTarefasAPI.Model;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;

namespace ListadeTarefas.Services.Implementações
{
    public class TarefaService : ITarefaService
    {
        private ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;

        public TarefaService (IMapper mapper, ITarefaRepository tarefaRepository)
        {
            _mapper = mapper;
            _tarefaRepository = tarefaRepository;
            
        }
        public async Task<IEnumerable<TarefaDTO>> GetAll()
        {
            var tarefas = await _tarefaRepository.GetAll();
            return _mapper.Map<IEnumerable<TarefaDTO>>(tarefas);

        }

        public async Task<TarefaDTO> GetTarefaById(int Id)
        {
            var tarefas = await _tarefaRepository.GetById(Id);
            return _mapper.Map<TarefaDTO>(tarefas);
        }

        public async Task TarefaCreate(TarefaDTO tarefasModel)
        {
            var tarefas = _mapper.Map<Tarefa>(tarefasModel);
            await _tarefaRepository.Create(tarefas);
            tarefasModel.Id_Tarefa = tarefas.Id_Tarefa;
        }

        public async Task TarefaDeleteById(int id)
        {
            var tarefas = await _tarefaRepository.GetById(id);
            await _tarefaRepository.Delete(tarefas.Id_Tarefa);
        }

        public async Task TarefaUpdate(TarefaDTO tarefasModel)
        {
            var tarefas = _mapper.Map<Tarefa>(tarefasModel);
            await _tarefaRepository.Update(tarefas);
        }
    }
}
