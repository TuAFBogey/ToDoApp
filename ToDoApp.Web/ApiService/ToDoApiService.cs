using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Web.DTOs;

namespace ToDoApp.Web.ApiService
{
    public class ToDoApiService
    {
        private readonly HttpClient _httpClient;

        public ToDoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ToDoDTO>> GetAllAsync()
        {
            IEnumerable<ToDoDTO> toDoDTOs;

            var response = await _httpClient.GetAsync("ToDoList");

            if (response.IsSuccessStatusCode)
            {
                toDoDTOs = JsonConvert.DeserializeObject<IEnumerable<ToDoDTO>>(await
                    response.Content.ReadAsStringAsync());
            }
            else
            {
                toDoDTOs = null;
            }

            return toDoDTOs;
        }

        public async Task<ToDoDTO> AddAsync(ToDoDTO toDoDTO)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(toDoDTO), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("todolist", stringContent);

            if (response.IsSuccessStatusCode)
            {
                toDoDTO = JsonConvert.DeserializeObject<ToDoDTO>(await response.Content.ReadAsStringAsync());

                return toDoDTO;
            }
            else
            {
                return null;
            }
        }

        public async Task<ToDoDTO> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"todolist/{id}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ToDoDTO>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Update(ToDoDTO toDoDTO)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(toDoDTO), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("todolist", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"todolist/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            {
                return false;
            }
        }
    }
}
