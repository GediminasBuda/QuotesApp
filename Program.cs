using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Lecture38QuotesApp.Models.ResponseModels;
using Microsoft.Extensions.DependencyInjection;

namespace Lecture38QuotesApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /*var startup = new Startup();*/
            var serviceProvider = new Startup().ConfigureServices();
            var quoteApp = serviceProvider.GetService<QuoteApp>();
            await quoteApp.StartAsync();
        }
    }
}
