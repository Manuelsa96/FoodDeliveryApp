using FoodDeliveryAppByManuel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FoodDeliveryAppByManuel.Services
{
    public static class ApiService
    {
        public static async Task<bool> RegisterUser(string name,string email,string password)
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
            var response = await httpClient.PostAsync("http://FoodApi/api/Accounts/Register", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }

        public static async Task<bool> Login(string email, string password)
        {
            var login = new Login()
            {
                Email = email,
                Password = password
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "aplication/json");
            var response = await httpClient.PostAsync("http://FoodApi/api/Accounts/Login", content);
            if (!response.IsSuccessStatusCode) return false;
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Token>(jsonResult);
            Preferences.Set("accessToken", result.access_token);
            Preferences.Set("accessToken", result.user_Id);
            Preferences.Set("accessToken", result.user_name);

            return true;
        }
    }
}
