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
    public partial class Form3 : Form
    {
        string namePlayer;
        int score;
        int levelGame;
        int linesRemoved;
        public Form3(Player newPlayerResults)
        {
            this.namePlayer = newPlayerResults.namePlayer;
            this.score = newPlayerResults.score;
            this.levelGame = newPlayerResults.lvl;
            this.linesRemoved = newPlayerResults.lines;
            InitializeComponent();
            labelName.Text = namePlayer;
            labelScore.Text = Convert.ToString(score);
            labelLevel.Text = Convert.ToString(levelGame);
            labelLines.Text = Convert.ToString(linesRemoved);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            // закрыть и timer start
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            
        }
    }
}
