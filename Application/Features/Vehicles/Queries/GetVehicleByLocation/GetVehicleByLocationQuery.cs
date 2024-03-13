using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Queries.GetVehicleByLocation
{
    public class GetVehicleByLocationQuery : IRequest<Response<VehicleDto>>
    {
        public int LocationId { get; set; }
        public string ClienteU { get; set; }
    }

    public class GetVehicleByLocationQueryHandler : IRequestHandler<GetVehicleByLocationQuery, Response<VehicleDto>>
    {
        private readonly IRepositoryAsync<Vehicle> _RepositoryAsync;
        private readonly IMapper _Mapper;


        public GetVehicleByLocationQueryHandler(IRepositoryAsync<Vehicle> repositoryAsync, IMapper mapper)
        {
            _RepositoryAsync = repositoryAsync;
            _Mapper = mapper;
        }

        public async Task<Response<VehicleDto>> Handle(GetVehicleByLocationQuery request, CancellationToken cancellationToken)
        {
            Vehicle vehicle;


            vehicle = await _RepositoryAsync.GetByIdAsync(request.LocationId);

                if (vehicle == null)
                {
                    throw new KeyNotFoundException($"Registro no encontrado con el id {request.LocationId}");
                }
                

            var vehicleDto = _Mapper.Map<VehicleDto>(vehicle);
            return new Response<VehicleDto>(vehicleDto);
        }
    }
}
