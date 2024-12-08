using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IveonBootcamp.Asynchronous
{
    public class Apod
    {
        [JsonPropertyName(Constants.HdImageUrl)]
        public string? HdImageUrl { get; set; }

        [JsonPropertyName(Constants.Title)]
        public string? Title { get; set; }
    }
}
