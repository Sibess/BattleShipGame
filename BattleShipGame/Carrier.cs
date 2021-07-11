using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipGame
{
   public class Carrier : Ship
    {
        public override int LengthOfShip()
        {
            return 5;
        }
        public override int Max()
        {
            return 5;
        }

        public override string Label()
        {
            return " C ";
        }
    }
}
