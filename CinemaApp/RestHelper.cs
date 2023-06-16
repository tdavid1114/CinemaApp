using Castle.Components.DictionaryAdapter.Xml;
using CinemaApp.Models;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static CinemaApp.Logic.MovieLogic;

namespace CinemaApp
{
    public class RestHelper
    {
        public MovieSample[] ListAll()
        {
            using var client = new HttpClient();
            var response = client.GetAsync("http://localhost:5099/Movie/ListAll").GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<MovieSample[]>(responseBody);
        }

        public List<string> ListGenre()
        {
            using var client = new HttpClient();
            var response = client.GetAsync("http://localhost:5099/Movie/ListGenre").GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<List<string>>(responseBody);
        }

        public MovieSample[] ListByGenre(string selectedGenre)
        {
            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:5099/Movie/ListByGenre/{selectedGenre}").GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<MovieSample[]>(responseBody);
        }

        public Movie GetSelectedMovie(int screeningId)
        {
            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:5099/Movie/Read/{screeningId}").GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<Movie>(responseBody);
        }

        public List<List<short>> ReadSeats(int screeningsId)
        {
            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:5099/Seat/ReadSeats/{screeningsId}").GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<List<List<short>>>(responseBody);
        }

        public void UpdateSeats(int row, int column, int screeningsId)
        {
            using var client = new HttpClient();
            var request = new
            {
                Row = row,
                Column = column,
                ScreeningsId = screeningsId
            };
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"http://localhost:5099/Seat/UpdateSeats/{row}/{column}/{screeningsId}", content).GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
        }

        public Account ReadUser(string username)
        {
            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:5099/Account/ReadUser/{username}").GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<Account>(responseBody);
        }

        public void CreateUser(string username, string password)
        {
            using var client = new HttpClient();
            var user = new
            {
                Username = username,
                Password = password
            };
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync($"http://localhost:5099/Account/CreateUser/{username}/{password}", content).GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
        }

        public void CreateTicket(string title, string day, string time, int row, int column, string user)
        {
            using var client = new HttpClient();
            var ticket = new
            {
                Title = title,
                Screeningda = day,
                Screeningtime = time,
                Seatrow = row,
                Seatcolumn = column,
                User = user
            };
            var json = JsonConvert.SerializeObject(ticket);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync($"http://localhost:5099/Ticket/CreateTicket/{title}/{day}/{time}/{row}/{column}/{user}", content).GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
        }

        public ObservableCollection<Ticket> ReadTicket(string currentuser)
        {
            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:5099/Ticket/ReadTicket/{currentuser}").GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<ObservableCollection<Ticket>>(responseBody);
        }
    }
}