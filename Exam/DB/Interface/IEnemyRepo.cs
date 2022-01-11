using System.Threading.Tasks;
using DB.Models;

namespace DB.Interface
{
    public interface IEnemyRepo : IRepository<Enemy>
    {
        Enemy GetRandomMonster();
    }
}