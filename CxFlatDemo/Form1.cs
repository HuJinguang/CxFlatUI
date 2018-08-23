using CxFlatUI;
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

  

        private void cxFlatSlider1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void cxFlatButton2_Click(object sender, EventArgs e)
        {
            cxFlatAlertBox1.ShowAlertBox(CxFlatAlertBox.AlertType.info, "123123", 1000);
        }

        private void cxFlatRoundButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
