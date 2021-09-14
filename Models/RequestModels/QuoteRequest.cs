using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lecture38QuotesApp.Models.RequestModels
{
    public class QuoteRequest
    {
        [JsonPropertyName("quote")]
        public QuoteR Quote { get; set; }
        
        public override string ToString()
        {
            return $"{Quote}";
        }
    }
    public class QuoteR
    {
        [JsonPropertyName("author")]
        public string Author { get; set; }
        [JsonPropertyName("body")]
        public string Body { get; set; }
       
        public override string ToString()
        {
            return $"Author: {Author}; {Body}";
        }
    }
}
