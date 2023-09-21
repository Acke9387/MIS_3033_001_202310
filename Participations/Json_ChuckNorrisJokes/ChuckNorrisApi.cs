using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json_ChuckNorrisJokes
{
    public class ChuckNorrisApi
    {

        [JsonProperty("value")]
        public string value { get; set; }

    }
}
