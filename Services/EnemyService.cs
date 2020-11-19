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
    }
}
