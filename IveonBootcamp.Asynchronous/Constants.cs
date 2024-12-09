using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace IveonBootcamp.Asynchronous
{
    public static class Constants
    {
        public const string BaseUrl = "https://api.nasa.gov/neo/rest/v1/feed?api_key=WtcSVGk41KsmKlnuBZiIAAemWxSlYTjTuFP2rdFf";
        public const string ApodBaseUrl = "https://api.nasa.gov/planetary/apod?api_key=WtcSVGk41KsmKlnuBZiIAAemWxSlYTjTuFP2rdFf";

        //Json Properties
        public const string NearEarthObjects = "near_earth_objects";
        public const string Name = "name";
        public const string Id = "id";
        public const string HdImageUrl = "hdurl";
        public const string Title = "title";
    }
}
