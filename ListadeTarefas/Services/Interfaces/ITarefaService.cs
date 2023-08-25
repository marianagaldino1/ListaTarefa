using ListadeTarefas.Models;

namespace ListadeTarefas.Services.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<TarefasModel>> GetAll();

        Task<TarefasModel> GetTarefaById(int Id);

        Task<TarefasModel> TarefaCreate(TarefasModel tarefasModel);

        Task<TarefasModel> TarefaUpdate(TarefasModel tarefasModel);

        Task<bool> TarefaDelete(int id);


    }
}
