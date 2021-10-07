using Fc.DomainServices.Definitions;
using Fc.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fc.Infraestructure.Definitions;
using Fc.Repository.Definitions;
using Microsoft.EntityFrameworkCore;

namespace Fc.DomainServices.Implementations
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ImageService(IImageRepository imageRepository, IUnitOfWork unitOfWork)
        {
            _imageRepository = imageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Upload(Image image)
        {
            _imageRepository.Create(image);
            await _unitOfWork.Commit();
        }

        public async Task Delete(Guid id)
        {
            var image = await _imageRepository.FindBy(x => x.Id == id).SingleOrDefaultAsync();

            if (image == null)
                throw new Exception("Image doesn't exists");

            _imageRepository.Delete(image);
            await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<Image>> GetAll()
        {
            return await _imageRepository.GetAll().ToListAsync();
        }
    }
}
