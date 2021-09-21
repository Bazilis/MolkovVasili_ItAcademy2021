﻿using ControlWorkApp.BLL.DTO;
using ControlWorkApp.BLL.Interfaces;
using ControlWorkApp.DAL.Entities;
using ControlWorkApp.DAL.Interfaces;
using FluentValidation;
using Mapster;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlWorkApp.BLL.Services
{
    public class OrderService : IService<OrderDto>
    {
        private readonly IRepository<OrderEntity> _orderRepository;
        private readonly IValidator<OrderDto> _orderValidator;
        private readonly ILogger _orderLogger;

        public OrderService(IRepository<OrderEntity> orderRepository, IValidator<OrderDto> orderValidator, ILogger orderLogger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));

            _orderValidator = orderValidator ?? throw new ArgumentNullException(nameof(orderValidator));

            _orderLogger = orderLogger ?? throw new ArgumentNullException(nameof(orderLogger));
        }

        public OrderDto GetById(int itemId)
        {
            OrderEntity orderEntityResult = _orderRepository.GetById(itemId);

            OrderDto orderDtoResult = orderEntityResult.Adapt<OrderDto>();

            return orderDtoResult;
        }

        public List<OrderDto> GetAll()
        {
            List<OrderEntity> existOrdersEntities = _orderRepository.GetAll().ToList();

            List<OrderDto> existOrdersDtos = existOrdersEntities.Adapt<List<OrderDto>>();

            return existOrdersDtos;
        }

        public OrderDto Create(OrderDto item)
        {
            var validationResult = _orderValidator.Validate(item);

            if (!validationResult.IsValid)
            {
                throw new ValidationException("Invalid order for create");
            }

            OrderEntity orderEntityForCreate = item.Adapt<OrderEntity>();

            OrderEntity orderEntityResult = _orderRepository.Create(orderEntityForCreate);

            item.Id = orderEntityResult.Id;

            _orderLogger.Information($"Create order {item.Name} in DB");

            return item;
        }

        public void Update(OrderDto item)
        {
            var validationResult = _orderValidator.Validate(item);

            if (!validationResult.IsValid)
            {
                throw new ValidationException("Invalid order for update");
            }

            OrderEntity orderEntityForUpdate = item.Adapt<OrderEntity>();

            _orderRepository.Update(orderEntityForUpdate);

            _orderLogger.Information($"Update order {item.Name} in DB");
        }

        public void Delete(OrderDto item)
        {
            OrderEntity orderEntityForDelete = item.Adapt<OrderEntity>();

            _orderRepository.Delete(orderEntityForDelete);

            _orderLogger.Information($"Delete order {item.Name} in DB");
        }
    }
}
