using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fc.Entities.Dto;
using Fc.Infraestructure.Implementations;
using Fc.Repository.Definitions;

namespace Fc.Repository.Implementations
{
    public class SourceRepository : RestClient, ISourceRepository
    {
        public Task<IEnumerable<MovieDto>> GetSources()
        {
            return Get<IEnumerable<MovieDto>>("/resource/yitu-d5am.json");
        }

        public SourceRepository(Dictionary<string, HttpClient> httpClients, Settings settings)
            :
            base(httpClients[settings.ApiName])
        {

        }
    }
}
