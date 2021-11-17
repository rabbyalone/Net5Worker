using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Worker.Parser
{
    public static class Parser<TEntity> where TEntity : class
    {
        public class Data
        {
            public IList<TEntity> Results { get; set; }
        }

        public static Data ParseJson(string json)
        {
            Data data = new Data();
            JObject jObject = JObject.Parse(json);

            if (jObject.HasValues)
            {
                if (jObject.First?.First != null)
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    data = JsonConvert.DeserializeObject<Data>(jObject.First.First.ToString(), settings);
                }
            }
            else
            {
                return new Data();
            }

            return data;
        }
    }
}
