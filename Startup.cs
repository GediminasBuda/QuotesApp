using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture38QuotesApp
{
    class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddHttpClient<IQuoteClient, QuoteClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://favqs.com/api/");//Username: root, password: TESTAS
                httpClient.DefaultRequestHeaders.Add("Authorization", "Token token=df412ba4d13f8019e24ec307738749f9");
            });
            services.AddSingleton<QuoteApp>();
            return services.BuildServiceProvider();
        }
    }
}
