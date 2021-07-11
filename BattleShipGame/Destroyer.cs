using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipGame
{
    public class Destroyer : Ship
    {
        public override int LengthOfShip()
        {
            return 2;
        }

        public override int Max()
        {
            return 7;
        }

        public override string Label()
        {
            return " D ";
        }

    }
}