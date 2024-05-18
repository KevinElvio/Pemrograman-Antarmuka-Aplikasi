using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Modul_4
{
    internal class User
    {
        [JsonProperty ("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("saldo")]
        public int Saldo { get; set; }
        [JsonProperty("hutang")]
        public int Hutang { get; set; }

        
    }
}
