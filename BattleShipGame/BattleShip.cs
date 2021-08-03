
namespace BattleShipGame
{
    public class BattleShip : Ship

    {
        public override int LengthOfShip()
        {
            return 4;
        }

        public override int MaximumHorizontalIndex()
        {
            return 2;
        }

        public override int MinimumVerticalIndex()
        {
            return 1;
        }

        public override int MaximumVerticalIndex()
        {
            return 4;
        }

        public override int MinimumHorizontalIndex()
        {
            return 1;
        }

        public override string Label()
        {
            return " B ";
        }
    }
}
