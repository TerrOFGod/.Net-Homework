namespace BL.Models
{
    public class Character
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int AttackModifier { get; set; }
        public int AttackPerRound { get; set; }
        public string Damage { get; set; }
        public int DamageModifier { get; set; }
        public int AC { get; set; }
    }
}