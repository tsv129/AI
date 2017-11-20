using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI5
{
    public partial class Form1 : Form
    {
        int[] gen = new int[12] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 };
        int[] ideal = new int[12] { 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 1, 0};
        Random rng = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tmp, rnged;
            for (int i=0; i < 50; i++)
            {
                rnged = rng.Next(12);
                tmp = gen[0];
                gen[0] = gen[rnged];
                gen[rnged] = tmp;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            for (int i=0; i<12;i++)
                label1.Text += gen[i].ToString()+"  ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int progres = 0;
            int pointer = 0;
            int turns = 0;
            bool finished = false;
            while (!finished)
            {
                turns++;
                if (gen[pointer] == ideal[progres])
                    progres++;
                pointer++;
                if (pointer == 12)
                    pointer -= 12;
                if (progres == 11)
                    finished = true;
            }
            MessageBox.Show(turns.ToString());
        }
    }
}
