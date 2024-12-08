using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IveonBootcamp.Asynchronous
{
    public class NearEarthObject
    {
        [JsonPropertyName(Constants.Id)]
        public string? Id { get; set; }

        [JsonPropertyName(Constants.Name)]
        public string? Name { get; set; }
    }
}
