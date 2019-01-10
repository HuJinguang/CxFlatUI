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
            //设置标题栏无按钮
            //this.ControlBox = false;
            //

            //多行文本框
            cxFlatTextBox2.Text =
                "A" + Environment.NewLine
                + "B" + Environment.NewLine
                + "C" + Environment.NewLine
                + "D" + Environment.NewLine
                + "E" + Environment.NewLine
                + "F" + Environment.NewLine
                + "G" + Environment.NewLine
                + "H" + Environment.NewLine
                + "I" + Environment.NewLine
                + "J" + Environment.NewLine
                + "K" + Environment.NewLine;
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
            foreach (var item in tabPage2.Controls)
            {
                if (item is CxFlatProgressBar)
                {
                    if (((CxFlatProgressBar)item).ValueNumber == 100)
                        ((CxFlatProgressBar)item).ValueNumber = 0;
                    ((CxFlatProgressBar)item).ValueNumber++;
                }
                if (item is CxFlatRoundProgressBar)
                {
                    if (((CxFlatRoundProgressBar)item).ValueNumber == 100)
                        ((CxFlatRoundProgressBar)item).ValueNumber = 0;
                    ((CxFlatRoundProgressBar)item).ValueNumber++;
                }
            }
        }

        private void cxFlatContextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            cxFlatButton2.Text = e.ClickedItem.Text;
        }

        private void cxFlatDatePicker1_onDateChanged(DateTime newDateTime)
        {
            label1.Text = cxFlatDatePicker1.Date.ToLongDateString();
        }
    }
}
