
namespace ConsoleApplication1
{
    public class Ship
    {
        private int life;
        private int size;
        public Ship(int size)
        {
            this.life = size;
            this.size = size;
        }
        public int GetLife()
        {
            return this.life;
        }
        
        public int GetSize()
        {
            return this.size;
        }
        public void DecreaseLife()
        {
            this.life--;
        }

    }
}