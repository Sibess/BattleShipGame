using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipGame
{
    public abstract class Ship
    {
        public abstract int LengthOfShip();

        public abstract int Max();

        public abstract string Label();
    }
}
