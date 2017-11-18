﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Abstractions.Api;
using Restaurant.Common.DataTransferObjects;

namespace Restaurant.Core.MockData
{
    public class MockOrdersApi : IOrdersApi
    {
        private static List<OrderDto> _dtos = new List<OrderDto>();
        public Task<IEnumerable<OrderDto>> GetAll()
        {
            return Task.FromResult(_dtos.AsEnumerable());
        }

        public Task Create(OrderDto dto)
        {
            _dtos.Add(dto);
            return Task.CompletedTask;
        }
    }
}
