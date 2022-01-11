using System;
using System.Linq;
using System.Threading.Tasks;
using DB.EF;
using DB.Interface;
using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Services
{
    public class EnemyRepo : Repository<Enemy>, IEnemyRepo
    {
        public EnemyRepo(ApplicationContext context) : base(context) { }

        public Enemy GetRandomMonster()
        {
            var count = _context.Monsters.Count();

            if (count == 0)
                throw new ArgumentOutOfRangeException();

            var rndSkip = new Random().Next(0, count);
            return _context.Monsters.Skip(rndSkip).First();
        }
    }
}