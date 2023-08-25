using ListadeTarefas.Repositorio.Interfaces;
using ListaTarefasAPI.Configurations;
using ListaTarefasAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace ListadeTarefas.Repositorio.Implementação
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Tarefa> Create(Tarefa tarefa)
        {
            var ultimaTarfa = await _context.Tarefas.OrderByDescending(c => c.Ordem).FirstOrDefaultAsync(); ;
            if(ultimaTarfa == null)
            {
                ultimaTarfa = new Tarefa();
                ultimaTarfa.Ordem = 0;
            }
            else
            {
                tarefa.Ordem = ultimaTarfa.Ordem += 1;
            }
          
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<Tarefa> Delete(int id)
        {
            var tarefa = await GetById(id);
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<IEnumerable<Tarefa>> GetAll()
        {
            return await _context.Tarefas.OrderBy(c => c.Ordem).ToListAsync();
        }

        public async Task<Tarefa> GetById(int id)
        {
            return await _context.Tarefas.Where(p => p.Id_Tarefa == id).FirstOrDefaultAsync();
        }

        public async Task<Tarefa> Update(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return tarefa;
        }
    }
}
