using Lecture38QuotesApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lecture38QuotesApp.Models.ResponseModels
{
    public class QuoteResponse
    {
        public int Page { get; set; }
        public bool Last_page { get; set; }

        [JsonPropertyName("quotes")]
        public IEnumerable<Quote> Quotes { get; set; }
        public override string ToString()
        {
            return $"{Quotes}";
        }
    }
    
}
