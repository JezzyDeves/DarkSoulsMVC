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
                ID = e.ID,
                Name = e.Name,
                Description = e.Description
            });

            return query.ToArray();
        }

        public LocationDetail GetLocationByID(int id)
        {
            var entity = ctx.Locations.Single(e => e.ID == id);

            return new LocationDetail
            {
                Name = entity.Name,
                Description = entity.Description,
                Bosses = entity.Bosses.Select(Boss => Boss.Name).ToList(),
                Enemies = entity.Enemies.Select(Enemy => Enemy.Name).ToList(),
                Items = entity.Items.Select(Item => Item.Name).ToList()
            };
        }
    }
}
