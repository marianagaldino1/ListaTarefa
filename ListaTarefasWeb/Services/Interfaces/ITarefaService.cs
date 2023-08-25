using ListaTarefasAPI.DTOS;

namespace ListadeTarefas.Services.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<TarefaDTO>> GetAll();

        Task<TarefaDTO> GetTarefaById(int Id);

        Task TarefaCreate(TarefaDTO tarefasModel);

        Task TarefaUpdate(TarefaDTO tarefasModel);

        Task TarefaDeleteById(int id);


    }
}
