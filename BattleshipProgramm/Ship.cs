namespace BattleshipProgramm
{
    public class Ship
    {
        public int Life { get; private set; }
        public int Size { get; }

        public Ship(int size)
        {
            this.Life = this.Size = size;
        }
        
        public void DecreaseLife()
        {
            this.Life--;
        }
    }
}
