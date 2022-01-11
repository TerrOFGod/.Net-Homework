using System;

namespace BL.Models
{
    public class Dice
    {
        private static readonly Random Rnd = new();
        private readonly int _countEdge;

        public Dice(int countEdge)
        {
            if (countEdge <= 0) throw new ArgumentOutOfRangeException();
            _countEdge = countEdge;
        }

        public int Roll() => Rnd.Next(1, _countEdge + 1);
    }
}