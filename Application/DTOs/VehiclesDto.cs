using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Application.DTOs
{
    public class VehicleDto
    {
        public int ID { get; set; }

        public string Brand { get; set; }

        public double Km { get; set; }

        public int Model { get; set; }

        public int LocationId { get; set; }

        public string Type {  get; set; }

        public string ClientU { get; set; }

    }
}
