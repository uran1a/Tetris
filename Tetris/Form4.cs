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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.Icon = new System.Drawing.Icon("N:\\code\\2021\\Study\\c#\\Tetris\\Tetris\\icon.ico");
            listView1.Columns.Clear();
            listView1.Columns.Add("Кнопка", 65, HorizontalAlignment.Center);
            listView1.Columns.Add("Команда", 165, HorizontalAlignment.Center);
            

            ListViewItem newItem1 = new ListViewItem("←");
            ListViewItem.ListViewSubItem Item1 = new ListViewItem.ListViewSubItem(newItem1, "Перемещение влево");
            newItem1.SubItems.Add(Item1);

            ListViewItem newItem2 = new ListViewItem("→");
            ListViewItem.ListViewSubItem Item2 = new ListViewItem.ListViewSubItem(newItem2, "Перемещение вправо");
            newItem2.SubItems.Add(Item2);

            ListViewItem newItem3 = new ListViewItem("↑");
            ListViewItem.ListViewSubItem Item3 = new ListViewItem.ListViewSubItem(newItem3, "Поворот на 90 вверх");
            newItem3.SubItems.Add(Item3);

            ListViewItem newItem4 = new ListViewItem("↓");
            ListViewItem.ListViewSubItem Item4 = new ListViewItem.ListViewSubItem(newItem4, "Поворот на 90 вниз");
            newItem4.SubItems.Add(Item4);

            ListViewItem newItem5 = new ListViewItem("Пробел");
            ListViewItem.ListViewSubItem Item5 = new ListViewItem.ListViewSubItem(newItem5, "Быстрое падение фигуры");
            newItem5.SubItems.Add(Item5);

            ListViewItem newItem6 = new ListViewItem("P");
            ListViewItem.ListViewSubItem Item6 = new ListViewItem.ListViewSubItem(newItem5, "Поставить паузу");
            newItem6.SubItems.Add(Item6);


            listView1.Items.AddRange(new ListViewItem[] { newItem1, newItem2, newItem3, newItem4, newItem5, newItem6 });

        }
    }
}
