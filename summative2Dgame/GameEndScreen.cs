using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System;
using System.Windows.Forms;
using System.Media;

namespace summative2Dgame
{
    public partial class GameEndScreen : UserControl
    {
        public GameEndScreen()
        {
            InitializeComponent();
            gameScore.Text = "Score: " + (GameScreen.score);
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
