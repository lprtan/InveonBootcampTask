using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IveonBootcamp.Asynchronous
{
    public class NasaResponse
    {
        [JsonPropertyName(Constants.NearEarthObjects)]
        public Dictionary<string, List<NearEarthObject>> NearEarthObjects { get; set; }
    }
}
