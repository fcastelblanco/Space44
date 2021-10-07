using System.Collections.Generic;
using System.Threading.Tasks;
using Fc.Entities.Dto;

namespace Fc.Repository.Definitions
{
    public interface ISourceRepository
    {
        Task<IEnumerable<MovieDto>> GetSources();
    }
}
