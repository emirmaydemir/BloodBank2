using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBYSİ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int start = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            start = start + 1;
            ProgressBar.Value = start;

            if(ProgressBar.Value == 100)
            {
                ProgressBar.Value = 0;
                timer1.Stop();
                Login l = new Login();
                l.Show();
                this.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
