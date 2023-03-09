using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace summative2Dgame
{
    internal class Player // creating the abilty to make a hero
    {
        public int x, y;
        public int speed = 8;
        public int width = 30;
        public int height = 50;
        public int gravity = 8;

        public Player(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public void Move(string direction)
        {
            if (direction == "up")
            {
              //  y -= 8;
            }
            if (direction == "down")
            {
                y += speed;
            }
            if (direction == "left")
            {
                x -= speed;
            }
            if (direction == "right")
            {
                x += speed;
            }
        }

        public void UpdatePositon()
        {
            x += speed;
            y += speed;
        }


    }
}
