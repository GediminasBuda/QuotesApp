using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lecture38QuotesApp.Models.Entities
{
    public class Quote
    {
        public IEnumerable<string> Tags { get; set; }
        public bool Favorite { get; set; }
        public string Author_permalink { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("favorites_count")]
        public int Favorites_count { get; set; }
        public int Upvotes_count { get; set; }
        public int Downvotes_count { get; set; }
        public bool Dialogue { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }
        public string Url { get; set; }
        public override string ToString()
        {
            return $"Id: {Id} Author: {Author}; {Body}; Likes: {Favorites_count}";
        }
    }
}
