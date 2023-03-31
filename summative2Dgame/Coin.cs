using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summative2Dgame
{
    internal class Coin
    {
        public int x;
        public int y;
        public int width;
        public int height;


        public Coin(int _x, int _y, int _height, int _width) 
        {  
            x = _x;
            y = _y;
            width = _width;
            height = _height;
        }


        public bool Collision(Player p)
        {
            Rectangle coinRec = new Rectangle(x, y, height, width);
            Rectangle playerRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (coinRec.IntersectsWith(playerRec))
            {
                return true;
            
            }
            return false;

        }


    }
}
