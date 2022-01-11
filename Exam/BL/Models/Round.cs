namespace BL.Models
{
    public class Round
    {
        public Character Player { get; set; }
        public Character Enemy { get; set; }
        public string PlayerLog { get; set; }
        
        public string EnemyLog { get; set; }
    }
}