using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    enum StateType { MISS = -1, HIT, KILL1, KILL2, KILL3, KILL4 }

    class Bot
    {
        public BattleField BattleField { get; private set; }
        public StateType State { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int ShotsCount { get; private set; }
        public List<KeyValuePair<int, int>> ShotsQueue { get; private set; }

        public Bot(BattleField battleField)
        {
            ShotsQueue = new List<KeyValuePair<int, int>>();
            BattleField = battleField;
            X = Y = -1;
            State = StateType.MISS;
        }

        public void Shot()
        {
            ShotsCount++;
            if (ShotsCount >= 100) return;
            switch (State)
            {
                case StateType.MISS:
                    if (ShotsQueue.Count == 0)
                    {
                        RandomShot();
                    }
                    else
                    {
                        State = (StateType)BattleField.Hit(ShotsQueue[0].Key, ShotsQueue[0].Value);
                        X = ShotsQueue[0].Key; Y = ShotsQueue[0].Value;
                        ShotsQueue.RemoveAt(0);
                    }
                    break;
                case StateType.HIT:
                    ShotsQueue.Clear();
                    for (int i = 1; i < 4; i++)
                    {
                        if (X - i > 0 && BattleField.FieldCells[X - i, Y].Sign == ' ') ShotsQueue.Add(new KeyValuePair<int, int>(X - i, Y));
                        if (Y + i < BattleField.Width && BattleField.FieldCells[X, Y + i].Sign == ' ') ShotsQueue.Add(new KeyValuePair<int, int>(X, Y + i));
                        if (X + i < BattleField.Height && BattleField.FieldCells[X + i, Y].Sign == ' ') ShotsQueue.Add(new KeyValuePair<int, int>(X + i, Y));
                        if (Y - i > 0 && BattleField.FieldCells[X, Y - i].Sign == ' ') ShotsQueue.Add(new KeyValuePair<int, int>(X, Y - i));
                    }
                    State = (StateType)BattleField.Hit(ShotsQueue[0].Key, ShotsQueue[0].Value);
                    X = ShotsQueue[0].Key; Y = ShotsQueue[0].Value;
                    ShotsQueue.RemoveAt(0);
                    break;
                case StateType.KILL1:
                case StateType.KILL2:
                case StateType.KILL3:
                case StateType.KILL4:
                    X = Y = -1;
                    ShotsQueue.Clear();
                    RandomShot();
                    break;
                default:
                    break;
            }
        }

        private void RandomShot()
        {
            Random random = new Random();
            int x = -1, y = -1;
            do
            {
                x = random.Next(0, BattleField.Height);
                y = random.Next(0, BattleField.Width);
            } while (BattleField.FieldCells[x, y].Sign != ' ');
            //Console.WriteLine($"BOT ({x + 1}, {y + 1})");
            State = (StateType)BattleField.Hit(x, y);
            X = x; Y = y;
        }
    }
}
