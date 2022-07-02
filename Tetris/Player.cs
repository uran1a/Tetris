using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Player
    {
        public string namePlayer;
        public int lvl;
        public int score;
        public int lines;

        public Player()
        {
            this.namePlayer = "";
            this.lvl = 0;
            this.score = 0;
            this.lines = 0;
        }
        public Player(string namePlayer, int lvl, int score, int lines)
        {
            this.namePlayer = namePlayer;
            this.lvl = lvl;
            this.score = score;
            this.lines = lines;
        }
        public void Print()
        {
            Console.WriteLine(namePlayer + "/" + lvl + "/" + score + "/" + lines);
        }
        public void SplitLine(string line)
        {
            String[] arr = line.Split(' ');
            namePlayer = arr[0];
            lvl = Convert.ToInt32(arr[1]);
            score = Convert.ToInt32(arr[2]);
            lines = Convert.ToInt32(arr[3]);
        }
        public string ConstrutcLine()
        {
            string line = namePlayer + ' ' + lvl + ' ' + score + ' ' + lines;
            return line;
        }
    }
}
