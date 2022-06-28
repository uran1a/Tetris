using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Icon = new System.Drawing.Icon("N:\\code\\2021\\Study\\c#\\Tetris\\Tetris\\icon.ico");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Form1 form1 = new Form1(textBox1.Text);
                textBox1.Clear();
                form1.Show();
            }
            else
                MessageBox.Show("Заполните поле: \"Имя игрока\"!");
        }
    }
}
