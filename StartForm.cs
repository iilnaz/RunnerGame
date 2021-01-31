using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunnerGame
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void PLAY_Click(object sender, EventArgs e)
        {
            
            Form1 f = new Form1();
            this.Hide();
            f.Show();
            
            
        }
    }
}
