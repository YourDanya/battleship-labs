using System;

namespace ConsoleApplication1
{
    public class FieldCell
    {
        private char sign;
        public bool isShip;
        public Ship ship;
        public FieldCell()
        {
            this.sign = '*';
            this.isShip = false;
        }

        public char GetSign()
        {
            return this.sign;
        }

        public int Hit()
        {
            if (this.isShip)
            {
                this.sign = 'x';
                this.isShip = false;
                this.ship.DecreaseLife();
                return this.ship.GetLife()==0 ? this.ship.GetSize(): 0;
            }
            else
            {
                return -1;
            }
        }
        
        public bool Add(Ship ship)
        {
            
            if(!this.isShip)
            {
                this.ship = ship;
                this.isShip = true;
                return true;
            }
            
            else
            {
                return false;
            }
        }
        
    }
    
}