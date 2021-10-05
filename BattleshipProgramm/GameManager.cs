using System;

namespace ConsoleApplication1
{
    public class GameManager
    {
        public BattleField yourBattleField;
        public BattleField opponentBattleField;

        private int height;
        private int width;

        public GameManager(int h, int w)
        {
            yourBattleField = new BattleField(h, w);
            opponentBattleField = new BattleField(h, w);

            height = h;
            width = w;
            
            Console.WriteLine("Play Game!");
        }

        public void AddShipInYourBattleField(int x1, int y1, int x2 = -1, int y2 = -1, int x3 = -1, int y3 = -1,  int x4 = -1, int y4 = -1)
        {
            int size = 1;
            
            if (x2 != -1 && y2 != -1)
                size++;
            if (x3 != -1 && y3 != -1)
                size++;
            if (x4 != -1 && y4 != -1)
                size++;
            
            yourBattleField.AddShip(size, x1, y1, x2, y2, x3, y3, x4, y4);
        }
        
        public void AddShipInOpponentBattleField(int x1, int y1, int x2 = -1, int y2 = -1, int x3 = -1, int y3 = -1,  int x4 = -1, int y4 = -1)
        {
            int size = 1;
            
            if (x2 != -1 && y2 != -1)
                size++;
            if (x3 != -1 && y3 != -1)
                size++;
            if (x4 != -1 && y4 != -1)
                size++;
            
            opponentBattleField.AddShip(size, x1, y1, x2, y2, x3, y3, x4, y4);
        }

        public void HitInYourBattleField(int x, int y)
        {
            yourBattleField.Hit(x, y);
        }
        
        public void HitInOpponentBattleField(int x, int y)
        {
            opponentBattleField.Hit(x, y);
        }
        
        public void Render()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(yourBattleField.fieldCells[i, j].GetSign() + "  ");
                }

                Console.Write("       ");
                
                for (int j = 0; j < width; j++)
                {
                    Console.Write(opponentBattleField.fieldCells[i, j].GetSign() + "  ");
                }
                
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}