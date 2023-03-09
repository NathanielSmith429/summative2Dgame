using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace summative2Dgame
{
    public partial class GameScreen : UserControl
    {
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

        Player hero;

        Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown;

       // Rectangle Floor = new Rectangle(0, 500, 1920, 1080);

        public GameScreen()
        {
            InitializeComponent();
            InitalizeGame();
        }

        public void InitalizeGame()
        {
            hero = new Player(200,200);
        }


        private void GameEngine_Tick_1(object sender, EventArgs e)
        {
            if (upArrowDown && hero.y > 0)
            {
              //  hero.Move("up");
            }
            if (downArrowDown && hero.y < this.Height - hero.width)
            {
                hero.Move("down");
            }
            if (leftArrowDown && hero.x > 0)
            {
                hero.Move("left");
            }
            if (rightArrowDown && hero.x < this.Width - hero.height)
            {
                hero.Move("right");
            }

            


            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(yellowBrush, hero.x, hero.y, hero.width, hero.height);

          //  e.Graphics.FillRectangle(blackBrush, Floor.X, Floor.Y, Floor.Width, Floor.Height);


        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
    }
}
