
namespace BattleShipGame
{
    public class Submarine : Ship
    {
        public override int LengthOfShip()
        {
            return 3;
        }

        public override int MaximumHorizontalIndex()
        {
            return 9;
        }

        public override int MinimumVerticalIndex()
        {
            return 1;
        }

        public override int MaximumVerticalIndex()
        {
            return 2;
        }

        public override int MinimumHorizontalIndex()
        {
            return 6;
        }

        public override string Label()
        {
            return " S ";
        }
    }
}
