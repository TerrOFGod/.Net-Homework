using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class Character
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public int HP { get; set; }
        
        [Required]
        public int AttackModifier { get; set; }
        
        [Required]
        public int AttackPerRound { get; set; }
        
        public string Damage { get; set; }
        
        [Required]
        public int DamageModifier { get; set; }
        
        [Required]
        public int AC { get; set; }
    }
}