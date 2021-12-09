using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Play Game!");
            BattleField battleField = new BattleField(autoGenerate: true);
            Bot bot = new Bot(battleField);
            battleField.Render();
            for (int i = 0; i < 80; i++)
            {
                bot.Shot();
                battleField.Render();
            }
        }
    }
}