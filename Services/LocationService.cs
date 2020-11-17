using Data;
using Models.LocationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LocationService
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();
        public bool CreateLocation(LocationCreate model)
        {
            var entity = new Location()
            {
                Name = model.Name,
                Description = model.Description
            };

            ctx.Locations.Add(entity);
            return ctx.SaveChanges() == 1;
        }

        public IEnumerable<LocationListItem> GetLocations()
        {
            var query = ctx.Locations.Select(e => new LocationListItem
            {
                Name = e.Name,
                Description = e.Description
            });

            return query.ToArray();
        }
    }
}
