using System;
using System.Media;
using System.Windows.Forms;

namespace Snake
{
    public partial class FormMain : Form
    {  
        public FormMain()
        {
            InitializeComponent();
            GameInit();
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            GameDraw(e.Graphics);
        }

        private void tLoop_Tick(object sender, EventArgs e)
        {
            GameUpdate();
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            GameReadKey(e);
        }
    }
}
