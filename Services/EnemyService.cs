using Data;
using Models.EnemyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EnemyService
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();

        public IEnumerable<EnemyListItem> GetEnemies()
        {
            var query = ctx.Enemies.Select(e => new EnemyListItem
            {
                EnemyID = e.EnemyID,
                Name = e.Name,
                Description = e.Description
            });

            return query.ToArray();
        }

        public EnemyDetail GetEnemyByID(int id)
        {
            var entity = ctx.Enemies.Single(e => e.EnemyID == id);

            return new EnemyDetail
            {
                EnemyID = entity.EnemyID,
                Name = entity.Name,
                Description = entity.Description,
                Health = entity.Health,
                LocationID = entity.LocationID,
                Location = entity.Location
            };
        }

        public bool CreateEnemy(EnemyCreate model)
        {
            var entity = new Enemy
            {
                Name = model.Name,
                Description = model.Description,
                Health = model.Health,
                LocationID = model.LocationID
            };

            ctx.Enemies.Add(entity);
            return ctx.SaveChanges() == 1;
        }

        public bool UpdateEnemy(EnemyEdit model)
        {
            var entity = ctx.Enemies.Single(e => e.EnemyID == model.EnemyID);

            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Health = model.Health;
            entity.Location = model.Location;
            entity.LocationID = model.LocationID;

            return ctx.SaveChanges() == 1;
        }

        public bool DeleteEnemy(int id)
        {
            var entity = ctx.Enemies.Single(e => e.EnemyID == id);

            ctx.Enemies.Remove(entity);

            return ctx.SaveChanges() == 1;
        }
    }
}
