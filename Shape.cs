using System;

namespace Tetris
{
	class Shape
	{
		public int x;
		public int y;
		public int[,] matrix;

		public Shape(int x, int y)
		{
			this.x = x;
			this.y = y;
			matrix = new int[3, 3]
			{
			{0,1,0 },
			{0,1,1},
			{0,0,1},
			};
		}
		public void MoveDowm() => y++;
		public void MoveRight() => x++;
		public void MoveLeft() => x--;
	}
}
