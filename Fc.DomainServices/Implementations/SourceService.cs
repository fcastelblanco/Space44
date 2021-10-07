using AutoMapper;
using Fc.DomainServices.Definitions;
using Fc.Entities.Domain;
using Fc.Repository.Definitions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fc.DomainServices.Implementations
{
    public class SourceService : ISourceService
    {
        private readonly IMapper _mapper;
        private readonly ISourceRepository _sourceRepository;

        public SourceService(ISourceRepository sourceRepository, IMapper mapper)
        {
            _sourceRepository = sourceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Movie>> Get()
        {
            var result = await _sourceRepository.GetSources();
            var data = _mapper.Map<IEnumerable<Movie>>(result);
            return data;
        }

        public async Task<IEnumerable<Movie>> Get(string address)
        {
            var result = await _sourceRepository.GetSources();
            var filter = result.Where(x => !string.IsNullOrEmpty(x.Location) && x.Location.ToLower().Contains(address.ToLower()));
            var data = _mapper.Map<IEnumerable<Movie>>(filter);
            return data;
        }
    }
}