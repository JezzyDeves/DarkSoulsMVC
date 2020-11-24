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

        public ItemList GetItemByID(int id)
        {
            var entity = ctx.Items.Single(e => e.ItemID == id);

            return new ItemList
            {
                ItemID = entity.ItemID,
                Name = entity.Name,
                Description = entity.Description,
                LocationID = entity.LocationID
            };
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

        public bool UpdateItem(ItemEdit model)
        {
            var entity = ctx.Items.Single(e => e.ItemID == model.ItemID);
            entity.ItemID = model.ItemID;
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.LocationID = model.LocationID;

            return ctx.SaveChanges() == 1;
        }

        public bool DeleteItem(int id)
        {
            var entity = ctx.Items.Single(e => e.ItemID == id);

            ctx.Items.Remove(entity);

            return ctx.SaveChanges() == 1;
        }
    }
}
