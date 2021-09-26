using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Play Game!");
            BattleField battleField=new BattleField(10, 10);
            battleField.Render();
            battleField.AddShip(2, 0,0,0,1);
            battleField.Hit(0,0);
            battleField.Render();
            battleField.Hit(0,1);
            battleField.Render();
            battleField.Hit(1,0);
            battleField.Render();
        }
    }
}