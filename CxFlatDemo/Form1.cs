using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CxFlatDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cxFlatRoundProgressBar1.ValueNumber += 10;
            if (timer1.Enabled)
                timer1.Stop();
            else
                timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cxFlatProgressBar1.ValueNumber < 100)
            {
                cxFlatProgressBar1.ValueNumber += 1;
                cxFlatRoundProgressBar1.ValueNumber += 1;
            }
            else
            {
                cxFlatRoundProgressBar1.ValueNumber = 0;
                cxFlatProgressBar1.ValueNumber = 0;
            }
        }

        private void cxFlatSlider1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
