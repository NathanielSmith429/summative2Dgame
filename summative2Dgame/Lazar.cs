using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace summative2Dgame
{
    internal class Lazar
    {
       public int x;
       public int y;
       public int length;
       public int width;
       public int lazarXspeed = -10;
      int size = 40;
      //  Random randGen = new Random();




        public Lazar(int _x, int _y, int _length, int _width) // creating a template for the lazers 
        {    
            x = _x; 
            y = _y; 
            length = _length; 
            width = _width;   

        }

        public void Move(int width, int height) // moving the lazers across the screen
        {
            x += lazarXspeed;

            if (x > width - size || x < 0)
            {
               
                   lazarXspeed *= -1;
            
            }
        }

        public bool Collision(Player p) // reversing the direction of the lazer when hitting the player
        {
            Rectangle lazarRec = new Rectangle(x, y, size, size);
            Rectangle playerRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (lazarRec.IntersectsWith(playerRec)) 
            {
                if (lazarXspeed > 0)
                {
                    x = p.x - size;
                }
                else
                {
                    x = p.x + size;
                }
                lazarXspeed *= -1;
                return true;
            }
            return false;

        }

        public bool Collision(Lazar l)
        {
            Rectangle lazarRec = new Rectangle(x, y, size, size);
            Rectangle lazar2Rec = new Rectangle(l.x, l.y, l.size, l.size);

            if (lazarRec.IntersectsWith(lazar2Rec))
            {
                if (lazarXspeed > 0)
                {
                    x = l.x - size;
                }
                else
                {
                    x = l.x + size;
                }
                lazarXspeed *= 1;
                return true;
            }
            return false;   
        }



        }
}
