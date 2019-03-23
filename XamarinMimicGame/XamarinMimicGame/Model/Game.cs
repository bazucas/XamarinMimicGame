using System;
using System.Collections.Generic;
using System.Text;
using XamarinMimicGame.Enums;

namespace XamarinMimicGame.Model
{
    public class Game
    {
        public DifficultyEnum Difficulty { get; set; }
        public short WordTime { get; set; }
        public short Rounds { get; set; }

        public Group GroupOne { get; set; }
        public Group GroupTwo { get; set; }
    }
}
