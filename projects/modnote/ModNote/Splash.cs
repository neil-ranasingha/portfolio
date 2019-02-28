using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModNote
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            //Starts the timer
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Stops the timer when it reaches 2s and loads the Main form
            Timer.Stop();
            Main frm = new Main();
            frm.Show();
            this.Hide();
        }
    }
}
