using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipGame 
{
   public class Submarine : Ship
    {
        public override int LengthOfShip()
        {
            return 3;
        }

        public override int Max()
        {
            return 6;
        }

        public override string Label()
        {
            return " S ";
        }
    }
}
