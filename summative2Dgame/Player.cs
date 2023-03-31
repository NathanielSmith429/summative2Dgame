using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace summative2Dgame
{
    internal class Player // creating the abilty to make a hero
    {
        public int x, y;
        public int xspeed = 8;
        public int yspeed = 8;
        public int width = 30;
        public int height = 50;
 

        public Player(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public void Move(string direction)
        {
            if (direction == "up")
            {
                y -= 50;
            }
            if (direction == "down")
            {
                y += yspeed;
            }
            if (direction == "left")
            {

                x -= xspeed;
            }
            if (direction == "right")
            {
                x += xspeed;
            }
        }
    }
}
