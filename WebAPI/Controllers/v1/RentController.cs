using Application.Features.Vehicles.Queries.GetAllVehicles;
using Application.Features.Vehicles.Queries.GetVehicleByLocation;
using Domain.Entities;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    //[ApiVersion("1.0")]
    public class RentController : BaseApiController
    {


        //GET
        //[HttpGet]
        //[Route("Todos los Vehiculos")]
        //public async Task<IActionResult> GetSQL()
        //{
        //    return Ok(await Mediator.Send(new GetAllVehiclesQuery()));
        //}

        //GET
        [HttpGet]
        [Route("Rentar Vehiculos Disponibles")]
        public async Task<IActionResult> Get([FromQuery] GetAllVehiclesQueryParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllVehiclesQueryParameter
            {
                //PageNumber = filter.PageNumber,
                //PageSize = filter.PageSize,
                LocationId = filter.LocationId,
                ClienteU = filter.ClienteU

            }));
        }

        ////GET
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    return Ok(await Mediator.Send(new GetVehicleByLocationQuery{ LocationId = id }));
        //}


      


    }
}
