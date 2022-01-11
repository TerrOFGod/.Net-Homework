using System.Text.Json.Serialization;

namespace BL.Models
{
    public class Fighters
    {
        [JsonPropertyName("player")]
        public Character Player { get; set; }
        
        [JsonPropertyName("player")]
        public Character Enemy { get; set; }

        public Fighters(Character player, Character enemy)
        {
            Player = player;
            Enemy = enemy;
        }

        public Fighters() { }
    }
}