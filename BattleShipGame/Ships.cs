using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipGame
{
    public abstract class Ship
    {
        public abstract int LengthOfShip();
        public abstract int MinimumHorizontalIndex();
        public abstract int MinimumVerticalIndex();
        public abstract int MaximumHorizontalIndex();
        public abstract int MaximumVerticalIndex();
        public abstract string Label();

    }
}
