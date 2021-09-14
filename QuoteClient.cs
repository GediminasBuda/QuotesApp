using Lecture38QuotesApp.Models.RequestModels;
using Lecture38QuotesApp.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Lecture38QuotesApp.Models.Entities;

namespace Lecture38QuotesApp
{
    class QuoteClient : IQuoteClient
    {
        private readonly HttpClient _httpClient;
        public QuoteClient (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Quote> AddQuote(QuoteRequest model, string userToken)
        {
            const string url = "quotes";
          
            var postJson = JsonSerializer.Serialize(model);
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(_httpClient.BaseAddress, url),
                Method = HttpMethod.Post,
                Content = new StringContent(postJson, Encoding.UTF8, "application/json")
        };
            request.Headers.Add("User-Token", userToken);

            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<Quote>();
        }

        public async Task<Quote> FavQuote(int id, string userToken)
        {
            var url = $"quotes/{id}/fav";
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(_httpClient.BaseAddress, url),
                Method = HttpMethod.Put
            };
            request.Headers.Add("User-Token", userToken);

            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<Quote>();

        }
        public async Task<CreateSessionResponse> CreateSession(CreateSessionRequest user)
        {
            var url = $"session";

            /* var postJson = JsonSerializer.Serialize(user);
             var request = new HttpRequestMessage();// gali buti modeliuojama sekanciai:

            request.RequestUri = new Uri(_httpCLient.BaseAddress, url);
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(postJson, Encoding.UTF8, "application/json");*/
            // ir kitaip:
            /* var postJson = JsonSerializer.Serialize(user);
             var request = new HttpRequestMessage
             {
                 RequestUri = new Uri(_httpClient.BaseAddress, url),
                 Method = HttpMethod.Post,
                 Content = new StringContent(postJson, Encoding.UTF8, "application/json")
              };
             var response = await _httpClient.SendAsync(request);
             return await response.Content.ReadFromJsonAsync<CreateSessionResponse>();*/

            // ir dar kitaip:

            var response = await _httpClient.PostAsJsonAsync(url, user);
            return await response.Content.ReadFromJsonAsync<CreateSessionResponse>();
        }


        public Task<Quote> GetQuote(int quoteid)
        {
            var url = $"quotes/{quoteid}";
            return _httpClient.GetFromJsonAsync<Quote>(url);
        }

        public Task<QuoteResponse> GetAllQuotes()
        {
            const string url = "quotes";
            return _httpClient.GetFromJsonAsync<QuoteResponse>(url);
        }

        public async Task<LogoutResponse> CancelSession(string userToken)
        {
            var url = $"session";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, url),
            };

            request.Headers.Add("User-Token", userToken);

            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<LogoutResponse>();
        }

        public Task<QuoteResponse> GetQuoteByName(string name, string surname)
        {
            var url = $"quotes/?filter={name}+{surname}&type=author";
            
            return _httpClient.GetFromJsonAsync<QuoteResponse>(url);
           
        }
    }
}
