using System;

namespace Game.Models.Ai.Utils
{
    [Flags]
    public enum EAxis
    {
        X = 0b001,
        Y = 0b010,
        Z = 0b100,
    }
}