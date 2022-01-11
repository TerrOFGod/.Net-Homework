using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BL.Infrastructure
{
    public static class Log
    {
        private static Data _fighters;
        private static readonly Dice CommonDice = new Dice(20);
        private static Dice _enemyDice;
        private static Dice _playerDice;

        public static List<Round> GetLog(Data fighters)
        {
            _playerDice = new Dice(int.Parse(fighters.Player.Damage.Split('d')[1]));
            _enemyDice = new Dice(int.Parse(fighters.Enemy.Damage.Split('d')[1]));

            var rounds = new List<Round>();

            while (fighters.Player.HP > 0 && fighters.Enemy.HP > 0)
            {
                var round = new Round
                {
                    Player = fighters.Player
                };
                if (fighters.Player.HP > 0)
                    round.PlayerLog = GetLog(fighters.Player, fighters.Enemy, _playerDice);

                if (fighters.Enemy.HP > 0)
                    round.EnemyLog = GetLog(fighters.Enemy, fighters.Player, _enemyDice);
                
                rounds.Add(round);
            }

            return rounds;
        }

        private static string GetLog(Character striker, Character defender, Dice dice)
        {
            var round = "";
            var count = int.Parse(striker.Damage.Split('d')[0]);

            for (var i = 0; i < count && defender.HP > 0; i++)
            {
                var check = CommonDice.Roll();

                round += $"{striker.Name}: {check}({striker.AttackModifier})";
                var isAttackSuccess = check != 1 && (check + striker.AttackModifier >= defender.AC
                                                     || check == 20);

                if (!isAttackSuccess)
                {
                    round += check == 1 ? ", critical miss. " : ", miss. ";
                    continue;
                }

                var rate = check == 20 ? 2 : 1;

                var attack = dice.Roll();
                var damage = rate * (attack + striker.DamageModifier);
                defender.HP -= damage;
                if (defender.HP < 0)
                    defender.HP = 0;

                round += $"{damage} damage {defender.Name} ({defender.HP})";
            }

            return round;
        }
    }
}