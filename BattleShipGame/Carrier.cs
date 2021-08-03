
namespace BattleShipGame
{
    public class Carrier : Ship
    {
        public override int LengthOfShip()
        {
            return 5;
        }
        public override int MaximumHorizontalIndex()
        {
            return 6;
        }

        public override int MinimumVerticalIndex()
        {
            return 5;
        }

        public override int MaximumVerticalIndex()
        {
            return 7;
        }

        public override int MinimumHorizontalIndex()
        {
            return 6;
        }

        public override string Label()
        {
            return " C ";
        }
    }
}
