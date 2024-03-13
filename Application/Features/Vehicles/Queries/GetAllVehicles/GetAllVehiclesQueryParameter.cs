using Application.DTOs;
using Application.Interfaces;
using Application.Parameters;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Queries.GetAllVehicles
{
    public class GetAllVehiclesQueryParameter : IRequest<Response<List<VehicleDto>>>
    {
        public string ClienteU { get; set; }
        public int LocationId { get; set; }
    }

    public class GetAllVehiclesQueryParameterHandler : IRequestHandler<GetAllVehiclesQueryParameter, Response<List<VehicleDto>>>
    {
        private readonly IRepositoryAsync<Vehicle> _RepositoryAsync;
       
        private readonly IMapper _Mapper;
      

        public GetAllVehiclesQueryParameterHandler(IRepositoryAsync<Vehicle> repositoryAsync, IMapper mapper)
        {
            _RepositoryAsync = repositoryAsync;
            _Mapper = mapper;
         
        }

        public async Task<Response<List<VehicleDto>>> Handle(GetAllVehiclesQueryParameter request, CancellationToken cancellationToken)
        {
            
            List<Vehicle> listVehicles = new();

            Filter filter = new()
            {
                
                ClienteU = request.ClienteU,
                LocationId = request.LocationId
            };


            //listVehicles = await _RepositoryAsync.ListAsync(new PagedVehiclesSpecification(filter));

            //Simulación llegada de base de datos
             listVehicles = TableSQL(filter);
            if (listVehicles.Count == 0)
                {
                    throw new KeyNotFoundException($"No hay vehiculos registrados con los parámetros indicados");
                }
                
            

            var vehiclesDto = _Mapper.Map<List<VehicleDto>>(listVehicles);
            return new Response<List<VehicleDto>>(vehiclesDto.OrderBy(c => c.LocationId).ToList());
        }

        public static List<Vehicle> TableSQL(Filter filters)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            List<Vehicle>  vehiclesD = new List<Vehicle>();

            vehicles.Add(new Vehicle { ID = 1, Brand = "Toyota", Model = 2019, LocationId = 3, Km = 2000, Type = "Corolla", ClienteU = filters.ClienteU });
            vehicles.Add(new Vehicle { ID = 2, Brand = "Honda", Model = 2020, LocationId = 2, Km = 3000, Type = "Civic", ClienteU = filters.ClienteU });
            vehicles.Add(new Vehicle { ID = 3, Brand = "Ford", Model = 2023, LocationId = 1, Km = 10000, Type = "Fusion", ClienteU = filters.ClienteU });


            foreach (Vehicle v in vehicles)
            {
               if(v.LocationId == filters.LocationId && v.LocationId.Equals(filters.ClienteU))
                vehiclesD.Add(v);

            }

            return vehiclesD;
        }
    }
}
