using ListadeTarefas.Models;
using ListadeTarefas.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace ListadeTarefas.Controllers
{
    public class TarefasController : Controller
    {
        private readonly ITarefaService _tarefaService;
        public TarefasController(ITarefaService tarefaService) 
        {

            _tarefaService = tarefaService;
        }

        public async Task<ActionResult> ListaTarefas()
        {
            return View();
        }
        public async Task<ActionResult> Lista()
        {
            var tarefas = await _tarefaService.GetAll();
            return Json(tarefas);
        }

       

        [HttpPost]
        public async Task<IActionResult> TarefaCreate(string dados)
        {
         
            var tarefa = JsonConvert.DeserializeObject<TarefasModel>(dados);
          
            var response = await _tarefaService.TarefaCreate(tarefa);
            string output = response != null ? "sucesso" : "erro";
            return Json(output);

        }

      
        [HttpPost]

        public async Task<IActionResult> TarefaUpdate(string dados)
        {

            var tarefa = JsonConvert.DeserializeObject<TarefasModel>(dados);

            var response = await _tarefaService.TarefaUpdate(tarefa);

            string output = response != null ? "sucesso" : "erro";
            return Json(output);

        }

       

        [HttpPost]
        public async Task<IActionResult> TarefaDelete(string dados)
        {
            var tarefa = JsonConvert.DeserializeObject<TarefasModel>(dados);

            var response = await _tarefaService.TarefaDelete(tarefa.Id_Tarefa);
            string output = response ? "sucesso" : "erro";
            return Json(output);
        }

        [HttpGet]
        public async Task<IActionResult> TarefaID(string ID)
        {

            var response = await _tarefaService.GetTarefaById(Convert.ToInt32(ID));

            return Json(response);

        }
    }
}
