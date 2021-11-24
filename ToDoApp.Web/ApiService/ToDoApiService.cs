using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

    }
}
