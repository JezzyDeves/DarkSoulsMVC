using Data;
using Models.ItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ItemService
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();

        public IEnumerable<ItemList> GetItems()
        {
            var query = ctx.Items.Select(e => new ItemList
            {
                ItemID = e.ItemID,
                Name = e.Name,
                Description = e.Description
            });

            return query.ToArray();
        }

        public bool CreateItem(ItemCreate model)
        {
            var entity = new Item
            {
                Name = model.Name,
                Description = model.Description,
                LocationID = model.LocationID
            };

            ctx.Items.Add(entity);
            return ctx.SaveChanges() == 1;
        }
    }
}
