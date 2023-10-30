using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic_Blog.PayLoad.Request
{ 
    public class OData<T>
    {
        [JsonProperty("@odata.context")]
        public string Metadata { get; set; }
        public T value { get; set; }
    }
}
