using Fc.Entities.Domain;
using Fc.Infraestructure.Definitions;
using Fc.Infraestructure.Implementations;
using Fc.Repository.Definitions;

namespace Fc.Repository.Implementations
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
