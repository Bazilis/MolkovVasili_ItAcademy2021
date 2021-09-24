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
    public class CustomerService : IService<CustomerDto>
    {
        private readonly IRepository<CustomerEntity> _customerRepository;
        private readonly IValidator<CustomerDto> _customerValidator;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(IRepository<CustomerEntity> customerRepository, IValidator<CustomerDto> customerValidator, ILogger<CustomerService> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));

            _customerValidator = customerValidator ?? throw new ArgumentNullException(nameof(customerValidator));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public CustomerDto GetById(int itemId)
        {
            CustomerEntity customerEntityResult = _customerRepository.GetById(itemId);

            CustomerDto customerDtoResult = customerEntityResult.Adapt<CustomerDto>();

            return customerDtoResult;
        }

        public List<CustomerDto> GetAll()
        {
            List<CustomerEntity> existCustomersEntities = _customerRepository.GetAll().ToList();

            List<CustomerDto> existCustomersDtos = existCustomersEntities.Adapt<List<CustomerDto>>();

            return existCustomersDtos;
        }

        public CustomerDto Create(CustomerDto item)
        {
            var validationResult = _customerValidator.Validate(item);

            if (!validationResult.IsValid)
            {
                throw new ValidationException("Invalid customer for create");
            }

            CustomerEntity customerEntityForCreate = item.Adapt<CustomerEntity>();

            CustomerEntity customerEntityResult = _customerRepository.Create(customerEntityForCreate);

            item.Id = customerEntityResult.Id;

            _logger.LogInformation($"Create customer {item.Name} in DB");

            return item;
        }

        public void Update(CustomerDto item)
        {
            var validationResult = _customerValidator.Validate(item);

            if (!validationResult.IsValid)
            {
                throw new ValidationException("Invalid customer for update");
            }

            CustomerEntity customerEntityForUpdate = item.Adapt<CustomerEntity>();

            _customerRepository.Update(customerEntityForUpdate);

            _logger.LogInformation($"Update customer {item.Name} in DB");
        }

        public void Delete(CustomerDto item)
        {
            CustomerEntity customerEntityForDelete = item.Adapt<CustomerEntity>();

            _customerRepository.Delete(customerEntityForDelete);

            _logger.LogInformation($"Delete customer {item.Name} in DB");
        }
    }
}
