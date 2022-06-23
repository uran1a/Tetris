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
        const int COL = 10;
        const int ROW = 20;
        const int SPEED = 500;
        const int MAXCOUNTCOLOR = 6;
        Shape currentShape;
        int sizeCell;
        int[,] tetrisMap = new int[ROW, COL];
        int linesRemoved;
        int Interval;
        int score;
        int levelGame;
        int indent;
        public Form1()
        {
            InitializeComponent();
            this.KeyUp += new KeyEventHandler(keyFunc);
            Init();
        }
        public void Init()
        {
            sizeCell = 35;
            linesRemoved = 0;
            score = 0;
            levelGame = 1;
            indent = 5;
            currentShape = new Shape(3, 0);
            Interval = SPEED;
            label1.Text = "Score: " + score;
            label1.Location = new Point(415, 50);
            label3.Text = "Level: " + levelGame;
            label3.Location = new Point(415, 275);
            label2.Text = "Lines: " + linesRemoved;
            label2.Location = new Point(415, 305);
            label4.Text = "Speed: " + Interval;
            label4.Location = new Point(415, 335);

            listView1.Location = new Point(415, 375);

           /* listView1.Items.Clear();
            for (int i = 0; i < size; i++)
            {
                ListViewItem newItem = new ListViewItem(Convert.ToString(i + 1));
                ListViewItem.ListViewSubItem TitleGroup = new ListViewItem.ListViewSubItem(newItem, list_groups[i]->TitleGroup);
                ListViewItem::ListViewSubItem ^ NameKurator = gcnew ListViewItem::ListViewSubItem(newItem, list_groups[i]->NameKurator);
                newItem->SubItems->Add(TitleGroup);
                newItem->SubItems->Add(NameKurator);
                ListViewPanel->Items->AddRange(gcnew cli::array < System::Windows::Forms::ListViewItem ^  > (1) { newItem });
            }*/


            this.DoubleBuffered = true;
            timer1.Interval = Interval;
            timer1.Tick += new EventHandler(update);
            timer1.Start();

            Invalidate();
        }
        private void keyFunc(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    timer1.Interval = 10;
                    break;
                case Keys.Up:
                    if (!IsIntersects())
                    {
                        ResetArea();
                        currentShape.RotateShape();
                        Merge();
                        Invalidate();
                    }
                    break;
                case Keys.Right:
                    if (!CollideHor(1))
                    {
                        ResetArea();
                        currentShape.MoveRight();
                        Merge();
                        Invalidate();
                    }
                    break;
                case Keys.Left:
                    if (!CollideHor(-1)) {
                        ResetArea();
                        currentShape.MoveLeft();
                        Merge();
                        Invalidate();
                    }
                    break;
            }
        }
        private void update(object sender, EventArgs e)
        {
            ResetArea();
            if (!Collide())
            {
                currentShape.MoveDowm();
            }
            else
            {
                Merge();
                SliceMap();
                timer1.Interval = Interval;
                currentShape.ResetShape(3, 0);
                if (Collide())
                {
                    for (int i = 0; i < ROW; i++)
                    {
                        for (int j = 0; j < COL; j++)
                        {
                            tetrisMap[i, j] = 0;
                        }
                    }
                
                timer1.Tick -= new EventHandler(update);
                timer1.Stop();
                Init();
                }
            }
            Merge();
            Invalidate();
        }
        public void ShowNextShape(Graphics e)
        {
            e.DrawRectangle(Pens.Black, new Rectangle(415, 100, 132, 166));
            for (int i = 0; i < currentShape.sizeNextMatrix; i++)
            {
                for (int j = 0; j < currentShape.sizeNextMatrix; j++)
                {
                    if(currentShape.nextMatrix[i,j] != 0)
                        e.FillRectangle(Brushes.Red, new Rectangle(425 + j * sizeCell + 1, 100 + i * sizeCell + 1, sizeCell - 1, sizeCell - 1));
                }
            }
        }
        public void SliceMap()
        {
            int count;
            int curRemovedLines = 0;
            for (int i = 0; i < ROW; i++)
            {
                count = 0;
                for (int j = 0; j < COL; j++)
                {
                    if (tetrisMap[i, j] != 0)
                        count++;
                }
                if (count == COL)
                {
                    curRemovedLines++;
                    for (int g = i; g >= 1; g--)
                    {
                        for (int h = 0; h < COL; h++)
                        {
                            tetrisMap[g, h] = tetrisMap[g - 1, h];
                        }
                    }
                }
            }
            for (int i = 0; i < curRemovedLines; i++)
            {
                score += 100 * (i + 1);
            }
            linesRemoved += curRemovedLines;

            //if (linesRemoved != 0 && linesRemoved % 5 == 0)
            if (linesRemoved >= (5 * levelGame))
            {
                if (Interval > 100)
                {
                    Interval -= 50;
                }
                levelGame++;
            }

            label1.Text = "Score: " + score;
            label2.Text = "Lines: " + linesRemoved;
            label3.Text = "Level: " + levelGame;
            label4.Text = "Speed: " + Interval;
        }
        public bool IsIntersects()
        {
            for (int i = currentShape.y; i < currentShape.y+currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.x; j < currentShape.x+currentShape.sizeMatrix; j++)
                {
                    if(j>=0 && j<= 7)
                    {
                        if (tetrisMap[i, j] != 0 && currentShape.matrix[i - currentShape.y, j - currentShape.x] == 0)
                            return true;
                    }
                }
            }
            return false;
        }
        public void Merge() //Заполнение карты
        {
            for (int i = currentShape.y; i < currentShape.y+currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.x; j < currentShape.x+currentShape.sizeMatrix; j++)
                {
                    if (currentShape.matrix[i - currentShape.y, j - currentShape.x] != 0)
                        tetrisMap[i, j] = currentShape.matrix[i - currentShape.y, j - currentShape.x];
                }
            }
        }
        public bool Collide()
        {
            for (int i = currentShape.y + currentShape.sizeMatrix - 1; i >= currentShape.y; i--)
            {
                for (int j = currentShape.x; j < currentShape.x + currentShape.sizeMatrix; j++)
                {
                    if(currentShape.matrix[i-currentShape.y, j-currentShape.x] != 0)
                    {
                        if (i + 1 == ROW)
                        {
                            return true;
                        }
                        if (tetrisMap[i + 1, j] != 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool CollideHor(int dir)
        {
            for (int i = currentShape.y + currentShape.sizeMatrix - 1; i >= currentShape.y; i--)
            {
                for (int j = currentShape.x; j < currentShape.x + currentShape.sizeMatrix; j++)
                {
                    if (currentShape.matrix[i - currentShape.y, j - currentShape.x] != 0)
                    {
                        if (j + 1 * dir > COL - 1 || j + 1 * dir < 0)
                            return true;
                        if (tetrisMap[i, j + 1 * dir] != 0)
                        {
                            if (j - currentShape.x + 1 * dir >= currentShape.sizeMatrix || j - currentShape.x + 1 * dir < 0)
                                return true;
                            if (currentShape.matrix[i - currentShape.y, j - currentShape.x + 1 * dir] == 0)
                                return true;
                        }
                    }
                }
            }
            return false;
        }
        public void ResetArea() //Полная очистка карты 
        {
            for (int i = currentShape.y; i < currentShape.y+currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.x; j < currentShape.x+currentShape.sizeMatrix; j++)
                {
                    if (i >= 0 && j >= 0 && i < ROW && j < COL) 
                        if (currentShape.matrix[i - currentShape.y, j - currentShape.x] != 0)
                            tetrisMap[i, j] = 0;
                }
            }
        }
        public void DrawMap(Graphics e) //Зарисовка фигуры
        {
            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {

                    Color[,] levelColor = new Color[,] { 
                        {Color.FromArgb(70, 54, 253), Color.FromArgb(174, 46, 37) }, // blue red
                        {Color.FromArgb(172, 35, 39), Color.FromArgb(206, 147, 39) }, //orange
                        {Color.FromArgb(65, 62, 243), Color.FromArgb(91, 166, 241) }, //blue
                        {Color.FromArgb(17, 139, 1), Color.FromArgb(135, 205, 2) }, //green
                        {Color.FromArgb(140, 0, 191), Color.FromArgb(201, 77, 216) }, //purple
                        {Color.FromArgb(164, 32, 113), Color.FromArgb(63, 207, 124) }, //ping
                    };
                    int sizeBorder = 5;
                    Brush FirstColor = new SolidBrush(levelColor[(levelGame - 1) % MAXCOUNTCOLOR, 0]);
                    Brush SecondColor = new SolidBrush(levelColor[(levelGame - 1) % MAXCOUNTCOLOR, 1]);
                    Pen BorderPen = new Pen(FirstColor, sizeBorder);
                    Pen WhiteBorderPen = new Pen(Brushes.White, 1);
                    int sizePoint = 3;
                    switch (tetrisMap[i, j])
                    {
                        case 1:
                        case 4:
                        case 7:
                            if (levelGame == 1)
                                e.FillRectangle(Brushes.White, new Rectangle(indent + j * sizeCell + 4, indent + i * sizeCell + 4, sizeCell - sizeBorder - 2, sizeCell - sizeBorder - 2));
                            e.DrawRectangle(BorderPen, new Rectangle(indent + j * sizeCell + 3, indent + i * sizeCell + 3, sizeCell - 6, sizeCell - 6));
                            e.FillRectangle(Brushes.White, indent + j * sizeCell + sizePoint, indent + i * sizeCell + sizePoint, sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indent + j * sizeCell + (sizePoint * 2), indent + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indent + j * sizeCell + (sizePoint * 2), indent + i * sizeCell + (sizePoint * 3), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indent + j * sizeCell + (sizePoint * 3), indent + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            break;
                        case 3:
                        case 6:
                            e.FillRectangle(FirstColor, new Rectangle(indent + j * sizeCell + 1, indent + i * sizeCell + 1, sizeCell - 1, sizeCell - 1));
                            e.FillRectangle(Brushes.White, indent + j * sizeCell + sizePoint, indent + i * sizeCell + sizePoint, sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indent + j * sizeCell + (sizePoint * 2), indent + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indent + j * sizeCell + (sizePoint * 2), indent + i * sizeCell + (sizePoint * 3), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indent + j * sizeCell + (sizePoint * 3), indent + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            break;
                        case 2:
                        case 5:
                            e.FillRectangle(SecondColor, new Rectangle(indent + j * sizeCell + 1, indent + i * sizeCell + 1, sizeCell - 1, sizeCell - 1));
                            e.FillRectangle(Brushes.White, indent + j * sizeCell + sizePoint, indent + i * sizeCell + sizePoint, sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indent + j * sizeCell + (sizePoint*2), indent + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indent + j * sizeCell + (sizePoint * 2), indent + i * sizeCell + (sizePoint * 3), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indent + j * sizeCell + (sizePoint * 3), indent + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            break;
                    }
                }
            }
        }
        public void DrawGrid(Graphics e) //Зарисовка карты 
        {
            for (int i = 0; i <= ROW; i++)
                e.DrawLine(Pens.Black, new Point(indent, indent + i * sizeCell), new Point(indent + COL * sizeCell, indent + i * sizeCell));
            for (int i = 0; i <= COL; i++)
                e.DrawLine(Pens.Black, new Point(indent + i * sizeCell, indent), new Point(indent + i * sizeCell, indent + ROW * sizeCell));
        }
        private void OnPaint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
            DrawMap(e.Graphics);
            ShowNextShape(e.Graphics);
        }
    }
}
