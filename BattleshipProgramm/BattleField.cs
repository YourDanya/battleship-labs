using System;

namespace BattleshipProgramm
{
    public class BattleField
    {
        public static int Width { get; private set; }
        public static int Height { get; private set; }
        private int[] Ships;
        public FieldCell[,] FieldCells;

        public BattleField(bool autoGenerate = false)
        {
            Width = Height = 10;
            Ships = new int[4];
            FieldCells = new FieldCell[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    FieldCells[i, j] = new FieldCell();
                }
            }
            if (autoGenerate)
            {
                AutoGenerate();
            }
        }

        public void AutoGenerate()
        {
            Random random = new Random();
            int x1, y1, x2, y2;
            for (int i = 4; i > 0; i--)
            {
                for (int j = 4 - i; j >= 0; j--)
                {
                    do
                    {
                        if (Convert.ToBoolean(random.Next(2)))
                        {
                            x1 = random.Next(Width - i);
                            x2 = x1 + i - 1;
                            y1 = y2 = random.Next(Height);
                        }
                        else
                        {
                            x1 = x2 = random.Next(Height);
                            y1 = random.Next(Width - i);
                            y2 = y1 + i - 1;
                        }
                    } while (!AddShip(i, x1, y1, x2, y2));
                }
            }
        }

        public void Render()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write("+---");
                }
                Console.WriteLine("+");
                for (int j = 0; j < Width; j++)
                {
                    Console.Write("| " + FieldCells[i, j].Sign + " ");
                }
                Console.WriteLine("|");
            }
            for (int j = 0; j < Width; j++)
            {
                Console.Write("+---");
            }
            Console.WriteLine("+");
        }

        public int Hit(int y, int x)
        {
            int res = FieldCells[y, x].Hit();
            switch (res)
            {
                case -1:
                    Console.WriteLine("Miss...");
                    break;
                case 0:
                    Console.WriteLine("Hit!");
                    break;
                case 1:
                    Ships[0]--;
                    Console.WriteLine("Killed ship with size one!");
                    break;
                case 2:
                    Ships[1]--;
                    Console.WriteLine("Killed ship with size two!");
                    break;
                case 3:
                    Ships[2]--;
                    Console.WriteLine("Killed ship with size three!");
                    break;
                case 4:
                    Ships[3]--;
                    Console.WriteLine("Killed ship with size four!");
                    break;
            }
            return res;
        }

        public bool CheckPlace(int size, int x1, int y1, int x2, int y2)
        {
            if (x1 >= Width || x2 >= Width || y1 >= Height || y2 >= Height || x1 < 0 || x2 < 0 || y1 < 0 || y2 < 0 ||
                (x1 != x2 && y1 != y2) || (size - 1 != Math.Abs(x1 - x2) && size - 1 != Math.Abs(y1 - y2)))
            {
                Console.WriteLine("Wrong coordinates or ship size!");
                return false;
            }

            if (Ships[size - 1] == 4 - size + 1)
            {
                Console.WriteLine("All ships of this size have already been added!");
                return false;
            }

            int xStart = Math.Max(Math.Min(x1 - 1, x2 - 1), 0);
            int xEnd = Math.Min(Math.Max(x1 + 1, x2 + 1), Height - 1);
            int yStart = Math.Max(Math.Min(y1 - 1, y2 - 1), 0);
            int yEnd = Math.Min(Math.Max(y1 + 1, y2 + 1), Width - 1);

            for (int i = xStart; i <= xEnd; i++)
            {
                for (int j = yStart; j <= yEnd; j++)
                {
                    if (FieldCells[j, i].IsShip)
                    {
                        Console.WriteLine("In this place we have a ship!");
                        return false;
                    }
                }
            }

            return true;
        }

        public bool AddShip(int size, int x1, int y1, int x2, int y2)
        {

            if (!CheckPlace(size, x1, y1, x2, y2)) return false;

            Ship ship = new Ship(size);
            for (int i = Math.Min(x1, x2); i <= Math.Max(x1, x2); i++)
            {
                for (int j = Math.Min(y1, y2); j <= Math.Max(y1, y2); j++)
                {
                    FieldCells[j, i].Add(ship);
                }
            }

            Ships[size - 1]++;

            Console.WriteLine("Ship added to the battlefield");
            return true;

        }
    }
}
