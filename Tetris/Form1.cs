using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tetris
{

    public partial class Form1 : Form
    {
        const int COL = 10;
        const int ROW = 20;
        const int SPEED = 500;
        const int MAXCOUNTCOLOR = 6;
        const int MAXCOUNTPLAYERS = 5;
        
        Shape currentShape;
        Player newPlayerResults;
        int sizeCell;
        int[,] tetrisMap = new int[ROW, COL];
        int linesRemoved;
        int Interval;
        int score;
        int levelGame;
        int indent;
        bool isPause;
        string namePlayer;

        public Form1(string nameUser)
        {
            this.namePlayer = nameUser;
            InitializeComponent();
            this.KeyUp += new KeyEventHandler(keyFunc);
            
            Init();
        }
        public void Init()
        {

            sizeCell = 30;
            linesRemoved = 0;
            score = 0;
            levelGame = 1;
            indent = 5;
            isPause = false;
            currentShape = new Shape(3, 0);
            Interval = SPEED;
            label1.Text = "Score: " + score;
            label1.Location = new Point(310, 255);
            label3.Text = "Level: " + levelGame;
            label3.Location = new Point(310, 280);
            label2.Text = "Lines: " + linesRemoved;
            label2.Location = new Point(310, 305);
            label4.Text = "Speed: " + Interval;
            label4.Location = new Point(310, 325);
            buttonPause.Location = new Point(310, 170);
            buttonInstruction.Location = new Point(310, 215);
            listView1.Columns.Clear();
            listView1.Columns.Add("#", 20, HorizontalAlignment.Center);
            listView1.Columns.Add("Имя", 55, HorizontalAlignment.Center);
            listView1.Columns.Add("Счёт", 50, HorizontalAlignment.Center);
            listView1.Location = new Point(310, 360);



            newPlayerResults = new Player(namePlayer, levelGame, score, linesRemoved);
            UpdateRating(newPlayerResults);

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
                case Keys.P:
                    Pause();
                    break;
                case Keys.Up:
                    if (!IsIntersects())
                    {
                        ResetArea();
                        currentShape.RotateShape(1);
                        Merge();
                        Invalidate();
                    }
                    break;
                case Keys.Down:
                    if (!IsIntersects())
                    {
                        ResetArea();
                        currentShape.RotateShape(-1);
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
                    newPlayerResults = new Player(namePlayer, levelGame, score, linesRemoved);
                    UpdateRating(newPlayerResults);
                    timer1.Tick -= new EventHandler(update);
                    timer1.Stop();

                    Form3 form3 = new Form3(newPlayerResults);
                    form3.Show();
                    Init();
                    Pause();
                }

            }
            Merge();
            Invalidate();
        }
        public void UpdateRating(Player newPlayerResults)
        {
            List<Player> ratingPlayer = new List<Player>();

            string path = @"N:\code\2021\Study\c#\Tetris\Tetris\Rating.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                for (int i = 0; (line = sr.ReadLine()) != null; i++)
                {
                    Player tempPlayer = new Player();
                    tempPlayer.SplitLine(line);
                    ratingPlayer.Add(tempPlayer);
                }
            }
            if(newPlayerResults.score > 0)
                ratingPlayer = CheckingName(ratingPlayer, newPlayerResults);
            ratingPlayer = sortScore(ratingPlayer);

            listView1.Items.Clear();
            for (int i = 0; i < ratingPlayer.Count; i++)
            {
                ListViewItem newItem = new ListViewItem(Convert.ToString(i+1));
                ListViewItem.ListViewSubItem Name = new ListViewItem.ListViewSubItem(newItem, ratingPlayer[i].namePlayer);
                ListViewItem.ListViewSubItem Score = new ListViewItem.ListViewSubItem(newItem, Convert.ToString(ratingPlayer[i].score));
                newItem.SubItems.Add(Name);
                newItem.SubItems.Add(Score);
                listView1.Items.AddRange(new ListViewItem[] { newItem });
            }

            for (int i = 0; i < ratingPlayer.Count; i++)
            {
                ratingPlayer[i].Print();
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < ratingPlayer.Count; i++)
                {
                    sw.WriteLine(ratingPlayer[i].ConstrutcLine());
                    if (i == (MAXCOUNTPLAYERS-1)) break;
                }
            }
        }
        public List<Player> CheckingName(List<Player> list, Player newPlayerResults)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (newPlayerResults.namePlayer == list[i].namePlayer)
                {
                    if (newPlayerResults.score >= list[i].score)
                        list[i] = newPlayerResults;
                    return list;
                }
            }
            list.Add(newPlayerResults);
            return list;
            
        }
        public List<Player> sortScore(List<Player> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i].score < list[j].score)
                    {
                        Player temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                    if (list[i].score == list[j].score)
                    {
                        if (list[i].lvl < list[j].lvl)
                        {
                            Player temp = list[i];
                            list[i] = list[j];
                            list[j] = temp;
                        }
                    }
                }
            }
            return list;
        }
        public void Pause()
        {
            if (isPause)
            {
                timer1.Start();
                labelPause.Visible = true;
            }
            else
            {
                timer1.Stop();
            }
            labelPause.Visible = !labelPause.Visible;
            isPause = !isPause;
        }
        public void ShowNextShape(Graphics e)
        {
            int sizeBorder = 5;
            int sizePoint = 3;
            int indentX1 = 305;
            int indentY1 = 120-95;
            int indentX2 = 330;
            int indentY2 = 120-95;
            int indentX3 = 330;
            int indentY3 = 120-95;
            int indentX4 = 335;
            int indentY4 = 120-95;
            int indentX5 = 350;
            int indentY5 = 130-95;
            int indentX6 = 315;
            int indentY6 = 130-95;
            int indentX7 = 350;
            int indentY7 = 150-95;

            Color[,] levelColor = new Color[,] {
                        {Color.FromArgb(70, 54, 253), Color.FromArgb(174, 46, 37) }, // blue red
                        {Color.FromArgb(172, 35, 39), Color.FromArgb(206, 147, 39) }, //orange
                        {Color.FromArgb(65, 62, 243), Color.FromArgb(91, 166, 241) }, //blue
                        {Color.FromArgb(17, 139, 1), Color.FromArgb(135, 205, 2) }, //green
                        {Color.FromArgb(140, 0, 191), Color.FromArgb(201, 77, 216) }, //purple
                        {Color.FromArgb(164, 32, 113), Color.FromArgb(63, 207, 124) }, //ping
                    };
            Brush FirstColor = new SolidBrush(levelColor[(levelGame - 1) % MAXCOUNTCOLOR, 0]);
            Brush SecondColor = new SolidBrush(levelColor[(levelGame - 1) % MAXCOUNTCOLOR, 1]);
            Pen BorderPen = new Pen(FirstColor, sizeBorder);
            Pen WhiteBorderPen = new Pen(Brushes.White, 1);
            for (int i = 0; i < currentShape.sizeNextMatrix; i++)
            {
                for (int j = 0; j < currentShape.sizeNextMatrix; j++)
                {
                    switch (currentShape.nextMatrix[i, j])
                    {
                        case 1:
                            e.FillRectangle(Brushes.White, new Rectangle(indentX1 + j * sizeCell + 4, indentY1 + i * sizeCell + 4, sizeCell - sizeBorder - 2, sizeCell - sizeBorder - 2));
                            e.DrawRectangle(BorderPen, new Rectangle(indentX1 + j * sizeCell + 3, indentY1 + i * sizeCell + 3, sizeCell - 6, sizeCell - 6));
                            e.FillRectangle(Brushes.White, indentX1 + j * sizeCell + sizePoint, indentY1 + i * sizeCell + sizePoint, sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX1 + j * sizeCell + (sizePoint * 2), indentY1 + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX1 + j * sizeCell + (sizePoint * 2), indentY1 + i * sizeCell + (sizePoint * 3), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX1 + j * sizeCell + (sizePoint * 3), indentY1 + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            break;
                        case 4:
                                e.FillRectangle(Brushes.White, new Rectangle(indentX4 + j * sizeCell + 4, indentY4 + i * sizeCell + 4, sizeCell - sizeBorder - 2, sizeCell - sizeBorder - 2));
                            e.DrawRectangle(BorderPen, new Rectangle(indentX4 + j * sizeCell + 3, indentY4 + i * sizeCell + 3, sizeCell - 6, sizeCell - 6)); ; ; ;
                            e.FillRectangle(Brushes.White, indentX4 + j * sizeCell + sizePoint, indentY4 + i * sizeCell + sizePoint, sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX4 + j * sizeCell + (sizePoint * 2), indentY4 + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX4 + j * sizeCell + (sizePoint * 2), indentY4 + i * sizeCell + (sizePoint * 3), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX4 + j * sizeCell + (sizePoint * 3), indentY4 + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            break;
                        case 7:
                                e.FillRectangle(Brushes.White, new Rectangle(indentX7 + j * sizeCell + 4, indentY7 + i * sizeCell + 4, sizeCell - sizeBorder - 2, sizeCell - sizeBorder - 2));
                            e.DrawRectangle(BorderPen, new Rectangle(indentX7 + j * sizeCell + 3, indentY7 + i * sizeCell + 3, sizeCell - 6, sizeCell - 6));
                            e.FillRectangle(Brushes.White, indentX7 + j * sizeCell + sizePoint, indentY7 + i * sizeCell + sizePoint, sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX7 + j * sizeCell + (sizePoint * 2), indentY7 + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX7 + j * sizeCell + (sizePoint * 2), indentY7 + i * sizeCell + (sizePoint * 3), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX7 + j * sizeCell + (sizePoint * 3), indentY7 + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            break;
                        case 3:
                            e.FillRectangle(FirstColor, new Rectangle(indentX2 + j * sizeCell + 1, indentY2 + i * sizeCell + 1, sizeCell - 1, sizeCell - 1));
                            e.FillRectangle(Brushes.White, indentX2 + j * sizeCell + sizePoint, indentY2 + i * sizeCell + sizePoint, sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX2 + j * sizeCell + (sizePoint * 2), indentY2 + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX2 + j * sizeCell + (sizePoint * 2), indentY2 + i * sizeCell + (sizePoint * 3), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX2 + j * sizeCell + (sizePoint * 3), indentY2 + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            break;
                        case 6:
                            e.FillRectangle(FirstColor, new Rectangle(indentX6 + j * sizeCell + 1, indentY6 + i * sizeCell + 1, sizeCell - 1, sizeCell - 1));
                            e.FillRectangle(Brushes.White, indentX6 + j * sizeCell + sizePoint, indentY6 + i * sizeCell + sizePoint, sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX6 + j * sizeCell + (sizePoint * 2), indentY6 + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX6 + j * sizeCell + (sizePoint * 2), indentY6 + i * sizeCell + (sizePoint * 3), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX6 + j * sizeCell + (sizePoint * 3), indentY6 + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            break;
                        case 2:
                            e.FillRectangle(SecondColor, new Rectangle(indentX3 + j * sizeCell + 1, indentY3 + i * sizeCell + 1, sizeCell - 1, sizeCell - 1));
                            e.FillRectangle(Brushes.White, indentX3 + j * sizeCell + sizePoint, indentY3 + i * sizeCell + sizePoint, sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX3 + j * sizeCell + (sizePoint * 2), indentY3 + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX3 + j * sizeCell + (sizePoint * 2), indentY3 + i * sizeCell + (sizePoint * 3), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX3 + j * sizeCell + (sizePoint * 3), indentY3 + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            break;
                        case 5:
                            e.FillRectangle(SecondColor, new Rectangle(indentX5 + j * sizeCell + 1, indentY5 + i * sizeCell + 1, sizeCell - 1, sizeCell - 1));
                            e.FillRectangle(Brushes.White, indentX5 + j * sizeCell + sizePoint, indentY5 + i * sizeCell + sizePoint, sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX5 + j * sizeCell + (sizePoint * 2), indentY5 + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX5 + j * sizeCell + (sizePoint * 2), indentY5 + i * sizeCell + (sizePoint * 3), sizePoint, sizePoint);
                            e.FillRectangle(Brushes.White, indentX5 + j * sizeCell + (sizePoint * 3), indentY5 + i * sizeCell + (sizePoint * 2), sizePoint, sizePoint);
                            break;
                    }
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
                    int sizeBorder = 5;
                    int sizePoint = 3;
                    Color[,] levelColor = new Color[,] { 
                        {Color.FromArgb(70, 54, 253), Color.FromArgb(174, 46, 37) }, // blue red
                        {Color.FromArgb(172, 35, 39), Color.FromArgb(206, 147, 39) }, //orange
                        {Color.FromArgb(65, 62, 243), Color.FromArgb(91, 166, 241) }, //blue
                        {Color.FromArgb(17, 139, 1), Color.FromArgb(135, 205, 2) }, //green
                        {Color.FromArgb(140, 0, 191), Color.FromArgb(201, 77, 216) }, //purple
                        {Color.FromArgb(164, 32, 113), Color.FromArgb(63, 207, 124) }, //ping
                    };
                    Brush FirstColor = new SolidBrush(levelColor[(levelGame - 1) % MAXCOUNTCOLOR, 0]);
                    Brush SecondColor = new SolidBrush(levelColor[(levelGame - 1) % MAXCOUNTCOLOR, 1]);
                    Pen BorderPen = new Pen(FirstColor, sizeBorder);
                    Pen WhiteBorderPen = new Pen(Brushes.White, 1);
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
            e.DrawRectangle(Pens.Black, new Rectangle(315, 5, 130, 160));
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
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            Pause();
        }
        private void listView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }
        private void buttonPause_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }
        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void buttonPause_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void buttonInstruction_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void buttonInstruction_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        private void buttonInstruction_MouseClick(object sender, MouseEventArgs e)
        {
            Pause();
            Form4 form4 = new Form4();
            form4.Show();
        }
    }
}
