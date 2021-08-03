
namespace BattleShipGame
{
    public class Cruiser : Ship
    {
        public override int LengthOfShip()
        {
            return 3;
        }

        public override int MaximumHorizontalIndex()
        {
            return 3;
        }

        public override int MinimumVerticalIndex()
        {
            return 8;
        }

        public override int MaximumVerticalIndex()
        {
            return 9;
        }

        public override int MinimumHorizontalIndex()
        {
            return 1;
        }

        public override string Label()
        {
            return " R ";
        }
    }
}
