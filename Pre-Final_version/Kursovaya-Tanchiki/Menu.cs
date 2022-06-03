using System;
using System.Windows.Forms;

namespace Kursovaya_Tanchiki
{
    public partial class Menu : Form
    {
        
        public Menu()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            this.Visible = false;
            game.ShowDialog();
            this.Visible = true;
            game.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reference spravka = new Reference();
            this.Visible = false;
           spravka.ShowDialog();
            this.Visible = true;
            spravka.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AboutProgram about = new AboutProgram();
            this.Visible = false;
            about.ShowDialog();
            this.Visible = true;
            about.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
