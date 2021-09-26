using System;

namespace ConsoleApplication1
{
    public class BattleField
    {
        private int size=0;
        private int width=0;
        private int height=0;
        private int ones=0;
        private int twos=0;
        private int threes=0;
        private int fours=0;
        public FieldCell[,] fieldCells;

        public BattleField(int height, int width, int ones, int twos, int threes, int fours, bool autoGenerate)
        {
            this.size = width*height;
            if (ones + twos * 2 + threes * 3 + fours * 4 > size)
            {
                return;
            }

            this.height = height;
            this.width = width;
            this.ones = ones;
            this.twos = twos;
            this.threes = threes;
            this.fours = fours;

            this.fieldCells = new FieldCell[height, width];

        }

        public BattleField(int height, int width)
        {
            this.height = height;
            this.width = width;
            this.size = width*height;
            this.fieldCells = new FieldCell[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    fieldCells[i, j]=new FieldCell();
                }
            }
            
            
        }

        public void AutoGenerate()
        {
            
        }

        public void Render()
        {
            for (int i = 0; i<height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(fieldCells[i,j].GetSign()+"  ");
                }
                Console.WriteLine();
            }
        }
        
        public void Hit(int y, int x)
        {
            int res=this.fieldCells[y,x].Hit();
            switch (res)
            {
                case -1: 
                    Console.WriteLine("miss");
                    break;
                case 0:
                    Console.WriteLine("hit");
                    break;
                case 1: 
                    this.ones--;
                    Console.WriteLine("killed ship with size one");
                    break;
                case 2: 
                    this.twos--;
                    Console.WriteLine("killed ship with size two");
                    break;
                case 3: 
                    this.threes--;
                    Console.WriteLine("killed ship with size three");
                    break;
                case 4: 
                    this.fours--;
                    Console.WriteLine("killed ship with size four");
                    break;
            }
        }

        public bool CheckPlace(int size, int x1, int y1, int x2, int y2)
        {
            if (x1>=this.width || x2>=this.width|| y1>=this.height|| y2>=this.height||
                x1<0 ||x2<0 || y1<0|| y2<0||
                (x1!=x2 && y1!=y2)|| size-1!= Math.Round(Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2))))
            {
                Console.WriteLine("Wrong coordinates or ship size!");
                return false;
            }
            
            
            if (x1 == x2)
            {
                for (int i = y1; i <=y2; i++)
                {
                    if (fieldCells[i, x1].isShip)
                    {
                        Console.WriteLine("You are trying to add a ship to the place with existed ship");
                        return false;
                    }
                }
            } 
            else
            {
                for (int i = x1; i <=x2; i++)
                {
                    if (fieldCells[y1, i].isShip)
                    {
                        Console.WriteLine("You are trying to add a ship to the place with existed ship");
                        return false;
                    }
                }
            }
            
            return true;
        }
        
        public void AddShip(int size, int x1, int y1, int x2, int y2)
        {

            if (!CheckPlace(size, x1, y1, x2, y2)) return;
            
            Ship ship = new Ship(size);
             if (x1 == x2)
            {
                for (int i = y1; i <=y2; i++)
                {
                    fieldCells[i,x1].Add(ship);
                }
            } 
            else
            {
                for (int i = x1; i <=x2; i++)
                {
                    fieldCells[y1,i].Add(ship);
                }
            }

            switch (size)
             {
               case 1: 
                   this.ones++;
                   break;
               case 2: 
                   this.twos++;
                   break;
               case 3: 
                   this.threes++;
                   break;
               case 4: 
                   this.fours++;
                   break;
             }
             
            Console.WriteLine("Ship added to the battlefield");
        
        }
        
    }
}