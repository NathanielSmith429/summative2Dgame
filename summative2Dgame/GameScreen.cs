using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.IO;
using System;
using System.Windows.Forms;
using System.Media;

namespace summative2Dgame
{
    public partial class GameScreen : UserControl
    {
        List<Coin> coins = new List<Coin>();
        List<Lazar> lazars = new List<Lazar>();
   
        Random randGen = new Random();

        // this messes with the screeen
        //System.Windows.Media.MediaPlayer goodCoin = new System.Windows.Media.MediaPlayer(); 

        Coin coin;
        Lazar funLazar;
        
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush darkRedBrush = new SolidBrush(Color.DarkRed);

        Player hero;
        int gravity;

        public static  int score;
        int livesNumber;

        Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown;
        bool isInAir = false; 

         Rectangle floor = new Rectangle(0, 583, 1080, 50);

        public GameScreen()
        {
            InitializeComponent();
            InitalizeGame();
        }
        public void InitalizeGame()
        {
            hero = new Player(500,500);      
            newCoin();
            newLazar();
            livesNumber = 3;
            score = 0;
          //  goodCoin.Open(new Uri(Application.StartupPath + "/Resources/blip.wav"));
        }

        private void GameEngine_Tick_1(object sender, EventArgs e) // moving the player
        {
            
            if (upArrowDown && hero.y > 0)
            {
               hero.Move("up");
            }
            if (downArrowDown && hero.y < this.Height - hero.height)
            {
                hero.Move("down");
            }
            if (leftArrowDown && hero.x > 0 && !isInAir)
            {
                hero.Move("left");
            }
            if (rightArrowDown && hero.x < this.Width - hero.width && !isInAir)
            {
                hero.Move("right");
            }

            Rectangle heroRect = new Rectangle(hero.x, hero.y, hero.width, hero.height);
        
            if (!heroRect.IntersectsWith(floor)) // fix the floor
            {
                isInAir = true;
                gravity = 15;
                hero.y += gravity;
            }
            else
            {
                isInAir = false;
                gravity = 0;
                hero.y = this.Height - 50;
               
            }
                if (coin.Collision(hero) == true)
            {
             //  goodCoin.Play();
                score++;
                newCoin();
                newLazar();
            }

            foreach (Lazar l in lazars) // moving the lazars around the screen
            {
                l.Move(this.Width, this.Height);
                
            }

            foreach (Lazar l in lazars) // lazers bounce off
            {
                if (l.Collision(hero))
                { 
                    livesNumber--;
                    break;
                }
            
            }

            //foreach (Lazar l in lazars) 

            //{
            //    if (l.Collision(funLazar))
            //    {
            //        break;
            //    }

            //}
            scoreLabel.Text = ("Score: " + score);

            if (livesNumber == 0)
            {
                GameEngine.Stop();
                Form1.ChangeScreen(this, new GameEndScreen());
            }
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e) // painting the screen
        {
            e.Graphics.FillRectangle(greenBrush, hero.x, hero.y, hero.width, hero.height);

            e.Graphics.FillRectangle(blackBrush, floor.X, floor.Y, floor.Width, floor.Height);

            for (int i = 0; i < coins.Count(); i++) // drawing coins
            {
             e.Graphics.FillEllipse(yellowBrush, coin.x, coin.y, coin.height, coin.width);
            }

            foreach (Lazar l in lazars) // painting lazars
            {
                e.Graphics.FillRectangle(redBrush, l.x, l.y, l.length, l.width);
            }

           if (livesNumber > 2) // removing live counters
            {
                e.Graphics.FillEllipse(darkRedBrush, 240, 18, 15, 15);
            }
            if (livesNumber> 1)
            {
                e.Graphics.FillEllipse(darkRedBrush, 220, 18, 15, 15);
            }
            if (livesNumber > 0)
            {
                e.Graphics.FillEllipse(darkRedBrush, 200, 18, 15, 15);
            }

        }
        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) // creating movment for the keys
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;

                case Keys.Right:
                    rightArrowDown = true;
                    break;

                case Keys.Up:
                    upArrowDown = true;
                    break;

                case Keys.Down:
                    downArrowDown = true;
                    break;
            }

        }
        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;

                case Keys.Right:
                    rightArrowDown = false;
                    break;

                case Keys.Up:
                    upArrowDown = false;
                    break;

                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }
        public void newCoin() // creating a new coin
        {
            int x = randGen.Next(60, this.Width - 30);
            int y = randGen.Next(30, this.Height - 30);
            coin = new Coin(x, y, 30, 30);
            coins.Add(coin);
        }

        public void newLazar() // creating a new lazar
        {
            int x = 1000;
            int y = randGen.Next(30, 480);
            funLazar = new Lazar (x, y, 40, 5);
            lazars.Add(funLazar);
        }
    }
}
