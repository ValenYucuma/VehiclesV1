using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vehicle 
    {
        public int ID { get; set; }

        public string Brand { get; set; }

        public double Km { get; set; }

        public int Model { get; set; }

        public int LocationId { get; set; }

        public string Type { get; set; }

        public string ClienteU {  get; set; }

    }
}
