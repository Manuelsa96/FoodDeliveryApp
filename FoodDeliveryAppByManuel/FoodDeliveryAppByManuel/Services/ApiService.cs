using FoodDeliveryAppByManuel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryAppByManuel.Services
{
    public class ApiService
    {
        public async Task<bool> RegisterUser(string name,string email,string password)
        {
            var register = new Register()
            {
                Name = name,
                Email = email,
                Password = password,
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(register);
            var content =new StringContent(json, Encoding.UTF8, "aplication/json");
            var response = await httpClient.PostAsync("direccionConveyorDeMiAPI/api/Accounts/Register", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }
    }
}
