using ControlWorkApp.BLL.DTO;
using ControlWorkApp.BLL.Interfaces;
using ControlWorkApp.DAL.Entities;
using ControlWorkApp.DAL.Interfaces;
using FluentValidation;
using Mapster;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlWorkApp.BLL.Services
{
    public class ProductService : IService<ProductDto>
    {
        private readonly IRepository<ProductEntity> _productRepository;
        private readonly IValidator<ProductDto> _productValidator;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IRepository<ProductEntity> productRepository, IValidator<ProductDto> productValidator, ILogger<ProductService> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

            _productValidator = productValidator ?? throw new ArgumentNullException(nameof(productValidator));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public ProductDto GetById(int itemId)
        {
            ProductEntity productEntityResult = _productRepository.GetById(itemId);

            ProductDto productDtoResult = productEntityResult.Adapt<ProductDto>();

            return productDtoResult;
        }

        public List<ProductDto> GetAll()
        {
            List<ProductEntity> existProductsEntities = _productRepository.GetAll().ToList();

            List<ProductDto> existProductsDtos = existProductsEntities.Adapt<List<ProductDto>>();

            return existProductsDtos;
        }

        public ProductDto Create(ProductDto item)
        {
            var validationResult = _productValidator.Validate(item);

            if (!validationResult.IsValid)
            {
                throw new ValidationException("Invalid product for create");
            }

            ProductEntity productEntityForCreate = item.Adapt<ProductEntity>();

            ProductEntity productEntityResult = _productRepository.Create(productEntityForCreate);

            item.Id = productEntityResult.Id;

            _logger.LogInformation($"Create product {item.Name} in DB");

            return item;
        }

        public void Update(ProductDto item)
        {
            var validationResult = _productValidator.Validate(item);

            if (!validationResult.IsValid)
            {
                throw new ValidationException("Invalid product for update");
            }
            
            ProductEntity productEntityForUpdate = item.Adapt<ProductEntity>();

            _productRepository.Update(productEntityForUpdate);

            _logger.LogInformation($"Update product {item.Name} in DB");
        }

        public void Delete(ProductDto item)
        {
            ProductEntity productEntityForDelete = item.Adapt<ProductEntity>();

            _productRepository.Delete(productEntityForDelete);

            _logger.LogInformation($"Delete product {item.Name} in DB");
        }
    }
}
