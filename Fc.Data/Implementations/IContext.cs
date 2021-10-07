using Fc.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fc.Data.Implementations
{
    public interface IContext
    {
        DbSet<Image> Images { get; set; }
    }
}