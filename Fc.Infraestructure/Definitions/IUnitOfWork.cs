using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Fc.Infraestructure.Definitions
{
    public interface IUnitOfWork
    {
        DbContext DbContext { get; }
        Task<int> Commit();
    }
}