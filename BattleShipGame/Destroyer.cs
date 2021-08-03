
namespace BattleShipGame
{
    public class Destroyer : Ship
    {
        public override int LengthOfShip()
        {
            return 2;
        }

        public override int MaximumHorizontalIndex()
        {
            return 4;
        }

        public override int MinimumVerticalIndex()
        {
            return 4;
        }

        public override int MaximumVerticalIndex()
        {
            return 6;
        }

        public override int MinimumHorizontalIndex()
        {
            return 3;
        }

        public override string Label()
        {
            return " D ";
        }

    }
}