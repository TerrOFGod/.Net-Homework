using System.Threading.Tasks;
using DB.Interface;
using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace DB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DBController : ControllerBase
    {
        private readonly IEnemyRepo _enemyRepository;

        public DBController(IEnemyRepo enemyRepository)
            => _enemyRepository = enemyRepository;

        [HttpPost]
        [Route("AddMonster")]
        public async Task Post(Enemy enemy)
            => await _enemyRepository.AddAsync(enemy);

        [HttpGet]
        [Route("GetRandomMonster")]
        public Enemy Get()
            => _enemyRepository.GetRandomMonster();
    }
}