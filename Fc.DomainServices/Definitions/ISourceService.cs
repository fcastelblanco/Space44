using Fc.Entities.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fc.DomainServices.Definitions
{
    public interface ISourceService
    {
        Task<IEnumerable<Movie>> Get();
        Task<IEnumerable<Movie>> Get(string address);
    }
}
