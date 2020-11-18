using Data;
using Models.BossModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BossService
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();
        public IEnumerable<BossListItem> GetBosses()
        {
            var query = ctx.Bosses.Select(e => new BossListItem
            {
                ID = e.ID,
                Name = e.Name,
                Description = e.Description,
                Health = e.Health
            });

            return query.ToArray();
        }

        public BossDetail GetBossByID(int id)
        {
            var entity = ctx.Bosses.Single(e => e.ID == id);

            return new BossDetail
            {
                ID = entity.ID,
                Name = entity.Name,
                Description = entity.Description,
                Health = entity.Health,
                Weakness = entity.Weakness,
                Tips = entity.Tips
            };
        }

        public bool CreateBoss(BossCreate model)
        {
            var entity = new Boss()
            {
                Name = model.Name,
                Description = model.Description,
                Health = model.Health,
                Weakness = model.Weakness,
                Location = model.Location,
                LocationID = model.ID,
                Tips = model.Tips
            };

            ctx.Bosses.Add(entity);
            return ctx.SaveChanges() == 1;
        }
    }
}
