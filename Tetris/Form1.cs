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
    
    public partial class Form1 : Form
    {
        const int COL = 8;
        const int ROW = 25;
        int sizeCell;
        int[,] tetrisMap = new int[COL, ROW];
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            sizeCell = 25;
            Invalidate();
        }
        public void DrawMap(Graphics g)
        {
            for (int i = 0; i < COL; i++)
            {
                g.DrawLine(Pens.Black, new Point(100, 100 + i * sizeCell), new Point(100 + 15 * sizeCell, 100 + i * sizeCell));
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            DrawMap(e.Graphics);
        }
    }
}
