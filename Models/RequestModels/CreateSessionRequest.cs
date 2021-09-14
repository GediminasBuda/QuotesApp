using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lecture38QuotesApp.Models.RequestModels
{
    public class CreateSessionRequest
    {
        [JsonPropertyName("user")]
        public User User { get; set; }
    }
   
}
