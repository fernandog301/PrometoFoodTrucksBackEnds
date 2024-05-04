using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PrometoFoodTrucksBackEnds.Models
{
    public class LocationModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
        public class Feature
        {
            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public string type { get; set; }

            [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
            public Properties properties { get; set; }

            [JsonProperty("geometry", NullValueHandling = NullValueHandling.Ignore)]
            public Geometry geometry { get; set; }
        }

        public class Geometry
        {
            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public string type { get; set; }

            [JsonProperty("coordinates", NullValueHandling = NullValueHandling.Ignore)]
            public List<double?> coordinates { get; set; }
        }

        public class Properties
        {
            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            public string name { get; set; }

            [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
            public string city { get; set; }

            [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
            public string state { get; set; }

            [JsonProperty("zip", NullValueHandling = NullValueHandling.Ignore)]
            public string zip { get; set; }

            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public string type { get; set; }

            public string wheelchairAccessible { get; set; }

            [JsonProperty("hoursOfOperation", NullValueHandling = NullValueHandling.Ignore)]
            public string hoursOfOperation { get; set; }

            
        }

        public class Root
        {
            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public string type { get; set; }

            [JsonProperty("features", NullValueHandling = NullValueHandling.Ignore)]
            public List<Feature> features { get; set; }
        }
    }
}