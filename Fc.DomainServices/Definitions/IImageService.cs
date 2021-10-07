using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fc.Entities.Domain;

namespace Fc.DomainServices.Definitions
{
    public interface IImageService
    {
        Task Upload(Image image);
        Task Delete(Guid id);
        Task<IEnumerable<Image>> GetAll();
    }
}