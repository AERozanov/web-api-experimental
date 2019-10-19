using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
  public  class OrderItem
    {
        [JsonProperty("orderitemid")]
        public virtual Int64 orderitemid { get; set; }
        [JsonProperty("orderfk")]
        public virtual Int64 orderfk { get; set; }
        [JsonProperty("id")]
        public virtual Guid id { get; set; }

        [JsonProperty("sku")]
        public virtual string sku { get; set; }
     
        [JsonProperty("price")]
        public virtual decimal price { get; set; }
    }
}
