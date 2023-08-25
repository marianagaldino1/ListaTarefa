using ListaTarefasAPI.DTOS;
using ListaTarefasAPI.Model;

namespace ListadeTarefas.Repositorio.Interfaces
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> GetAll();
        Task<Tarefa> GetById(int id);
        Task<Tarefa> Create(Tarefa tarefa);
        Task<Tarefa> Update(Tarefa tarefa);
        Task<Tarefa> Delete(int id);
    }
}
