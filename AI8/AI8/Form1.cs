using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI8
{
    public partial class Form1 : Form
    {
        private int[,] XY = new int[3, 3] { { 3, 2, 1 }, { 0, 0, 0 }, { 0, 0, 0 } };
        public Form1()
        {
            InitializeComponent();
        }

        private void MoveBlock(int from, int to)
        {
            for (int i = 2; i != -1;i--)
            {
                if (XY[from, i] != 0)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if ((XY[to, j] != 0) & (XY[to, j] < XY[from, i]))
                            break;
                        if (XY[to, j] == 0)
                        {
                            XY[to, j] = XY[from, i];
                            XY[from, i] = 0;
                            Sync();
                            return;
                        }
                    }
                }
            }
        }

        private void Sync()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (XY[i, j] != 0)
                        ReDraw(i, j);
                }
            }
        }

        private void ReDraw(int i, int j)
        {
            switch (XY[i, j])
            {
                case 1:
                    {
                        textBox3.Location = new Point(50 + (i * 175), 100 - 25 * j);
                        break;
                    }
                case 2:
                    {
                        textBox2.Location = new Point(50 + (i * 175), 100 - 25 * j);
                        break;
                    }
                case 3:
                    {
                        textBox1.Location = new Point(50 + (i * 175), 100 - 25 * j);
                        break;
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoveBlock(0, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MoveBlock(0, 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MoveBlock(1, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MoveBlock(1, 2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MoveBlock(2, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MoveBlock(2, 1);
        }
    }
}