using AutoMapper;
using ListadeTarefas.Models;
using ListadeTarefas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ListadeTarefas.Services.Implementações
{
    public class TarefaService : ITarefaService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string apiEndpoint = "/api/tarefas/";
        private readonly JsonSerializerOptions _options;
        private TarefasModel tarefaModel;
        private IEnumerable<TarefasModel> tarefasVM;

        public TarefaService (IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<IEnumerable<TarefasModel>> GetAll()
        {
            var client = _clientFactory.CreateClient("TarefasApi");

            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    tarefasVM = await JsonSerializer
                                .DeserializeAsync<IEnumerable<TarefasModel>>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return tarefasVM;

        }

        public async Task<TarefasModel> GetTarefaById(int Id)
        {
            var client = _clientFactory.CreateClient("TarefasApi");

            using (var response = await client.GetAsync(apiEndpoint + Id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    tarefaModel = await JsonSerializer
                                .DeserializeAsync<TarefasModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return tarefaModel;
        }

        public async Task<TarefasModel> TarefaCreate(TarefasModel tarefasModel)
        {
            var client = _clientFactory.CreateClient("TarefasApi");

            StringContent content = new StringContent(JsonSerializer.Serialize(tarefasModel),
                    Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    tarefaModel = await JsonSerializer
                                .DeserializeAsync<TarefasModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return tarefaModel;
        }

        public async Task<bool> TarefaDelete(int id)
        {
            var client = _clientFactory.CreateClient("TarefasApi");
            
            using (var response = await client.DeleteAsync(apiEndpoint +  id))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

            }
            return true;
        }

        public async Task<TarefasModel> TarefaUpdate(TarefasModel tarefasModel)
        {
            var client = _clientFactory.CreateClient("TarefasApi");
            TarefasModel productUpdate = new TarefasModel();


            using (var response = await client.PutAsJsonAsync(apiEndpoint, tarefasModel))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productUpdate = await JsonSerializer
                                .DeserializeAsync<TarefasModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return productUpdate;
        }
    }
}
