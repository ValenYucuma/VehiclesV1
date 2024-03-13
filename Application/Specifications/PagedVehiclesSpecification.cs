using Ardalis.Specification;
using Domain.Entities;
using System.Linq;

namespace Application.Specifications
{
    public class Filter
    {
        public int LocationId { get; set; }
        public string ClienteU { get; set; }
    }

    public class PagedVehiclesSpecification : Specification<Vehicle>
    {
        public PagedVehiclesSpecification(Filter filter)
        {
            

            if (filter.LocationId != 0)
                Query.Search(x => x.LocationId.ToString(), "%" + filter.LocationId + "%");

            if (!string.IsNullOrEmpty(filter.ClienteU))
                Query.Search(x => x.ClienteU, "%" + filter.ClienteU + "%");
        }
    }
}
