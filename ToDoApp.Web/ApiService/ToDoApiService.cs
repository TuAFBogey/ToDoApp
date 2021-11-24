using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ToDoApp.Web.ApiService
{
    public class ToDoApiService
    {
        private readonly HttpClient _httpClient;

        public ToDoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
