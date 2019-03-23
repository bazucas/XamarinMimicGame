using System;
using XamarinMimicGame.Enums;

namespace XamarinMimicGame.Model
{
    public class Game
    {
        private DifficultyEnum _difficulty;

        public int Difficulty
        {
            get => (int) _difficulty;
            set => _difficulty = (DifficultyEnum) Enum.Parse(typeof(DifficultyEnum), value.ToString());
        }

        public short WordTime { get; set; }
        public short Rounds { get; set; }

        public Group GroupOne { get; set; }
        public Group GroupTwo { get; set; }
    }
}