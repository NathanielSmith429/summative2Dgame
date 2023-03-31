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
    public partial class MenuScreen : UserControl
    {
        SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.lakeSound);
        public MenuScreen()
        {
            InitializeComponent();
            
            soundPlayer.Play();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
            soundPlayer.Stop();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void instructionsButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new InstructionsScreen());
            soundPlayer.Stop();
        }
    }
}
