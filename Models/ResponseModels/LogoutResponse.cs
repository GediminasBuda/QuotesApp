using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lecture38QuotesApp.Models.ResponseModels
{
    public class LogoutResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        public override string ToString()
        {
            return Message;
        }
    }
}
