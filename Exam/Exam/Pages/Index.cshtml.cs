using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models;

namespace UI.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty] 
        public Character Player { get; set; }
        
        [Required]
        [BindProperty] 
        public int DiceCount { get; set; }
        
        [Required]
        [BindProperty] 
        public int Dice { get; set; }
        
        public List<Round> Log { get; set; }

        private Character Monster { get; set; }
        
        private readonly HttpClient _client = new();
        
        private readonly Uri _urlGettingRandomMonster 
            = new("https://localhost:5011/DB/GetRandomMonster");
        
        private readonly Uri _urlPostingFighters 
            = new("https://localhost:5021/BL/PostFighters");
        
        public async Task OnPost()
        {
            if (!ModelState.IsValid) return;
            Player.Damage = DiceCount + "d" + Dice;
            Monster = await _client.GetFromJsonAsync<Character>(_urlGettingRandomMonster);

            var fighters = new Data
            {
                Player = Player,
                Enemy = Monster
            };

            var resp = await _client.PostAsJsonAsync(_urlPostingFighters, fighters);
            Log = await resp.Content.ReadFromJsonAsync<List<Round>>();
            Player = Log?.Last().Player;
        }
    }
}
