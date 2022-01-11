using System.Text.Json.Serialization;

namespace UI.Models
{
    public class Fighters
    {
        public Character Player { get; set; }
        
        public Character Enemy { get; set; }

        public Fighters(Character player, Character enemy)
        {
            Player = player;
            Enemy = enemy;
        }

        public Fighters() { }
    }
}