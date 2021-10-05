namespace BattleshipProgramm
{
    public class FieldCell
    {
        public char Sign { get; private set; }
        public bool IsShip;
        public Ship Ship;

        public FieldCell()
        {
            Sign = ' ';
            IsShip = false;
        }

        public int Hit()
        {
            if (IsShip)
            {
                Sign = 'x';
                IsShip = false;
                Ship.DecreaseLife();
                return Ship.Life == 0 ? Ship.Size : 0;
            }
            else
            {
                Sign = '-';
                return -1;
            }
        }

        public bool Add(Ship ship)
        {
            if (!IsShip)
            {
                Sign = ' ';
                Ship = ship;
                IsShip = true;
                return true;
            }
            return false;
        }
    }
}
