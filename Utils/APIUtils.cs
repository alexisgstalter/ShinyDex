using Newtonsoft.Json;
using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShinyDex.Utils
{
    class APIUtils
    {
        public async static Task<List<PokeApiNet.Version>> GetAllVersions()
        {
            using (WebClient client = new WebClient())
            {
                List<PokeApiNet.Version> res = new List<PokeApiNet.Version>();
                string json = await client.DownloadStringTaskAsync("https://pokeapi.co/api/v2/version?limit=-1");
                var versions = JsonConvert.DeserializeObject<dynamic>(json);

                List<Task<PokeApiNet.Version>> tasks = new List<Task<PokeApiNet.Version>>();

                using (PokeApiClient api = new PokeApiClient())
                {
                    foreach (var version in versions.results)
                    {
                        tasks.Add(Task.Run(async () =>
                        {
                            var versionDetails = await api.GetResourceAsync<PokeApiNet.Version>((string)version.name);
                            versionDetails.Name = versionDetails.Names.Where(n => n.Language.Name == "fr").FirstOrDefault()?.Name;
                            return versionDetails;
                        }));
                    }

                    var versionDetailsList = await Task.WhenAll(tasks);
                    res.AddRange(versionDetailsList);
                }

                return res;
            }
        }
    }
}
