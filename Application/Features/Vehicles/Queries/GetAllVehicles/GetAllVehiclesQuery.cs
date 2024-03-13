using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Queries.GetAllVehicles
{
    public class GetAllVehiclesQuery : IRequest<Response<List<VehicleDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int LocalidadId { get; set; }

        public string ClienteU { get; set; }
    }

    public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQuery, Response<List<VehicleDto>>>
    {
        private readonly IRepositoryAsync<Vehicle> _RepositoryAsync;
        private readonly IMapper _Mapper;

        public GetAllVehiclesQueryHandler(IRepositoryAsync<Vehicle> repositoryAsync, IMapper mapper)
        {
            _RepositoryAsync = repositoryAsync;
            _Mapper = mapper;
        }

        public async Task<Response<List<VehicleDto>>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
        {
            var vehiculos = await _RepositoryAsync.ListAsync(cancellationToken);

            vehiculos.Add(new Vehicle { ID = 1, Brand = "Toyota", Model = 2019, LocationId = 3, Km = 2000, Type = "Corolla"});
            vehiculos.Add(new Vehicle { ID = 2, Brand = "Honda", Model = 2020, LocationId = 2, Km = 3000, Type = "Civic"});
            vehiculos.Add(new Vehicle { ID = 3, Brand = "Ford", Model = 2023, LocationId = 1, Km = 10000, Type = "Fusion"});
            
            if (vehiculos.Count == 0)
            {
                throw new KeyNotFoundException($"No hay vehiculos");
            }
            else
            {
                List<VehicleDto> vehiculosDto = new List<VehicleDto>();

                foreach (var cliente in vehiculos)
                {
                    vehiculosDto.Add(_Mapper.Map<VehicleDto>(cliente));
                }

                return new Response<List<VehicleDto>>(vehiculosDto.OrderBy(c => c.LocationId).ToList());
            }
        }
    }
}
