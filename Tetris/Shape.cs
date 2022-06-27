using System;

namespace Tetris
{
	class Shape
	{
		public int x;
		public int y;
		public int[,] matrix;
		public int[,] nextMatrix;
		public int sizeMatrix;
		public int sizeNextMatrix;

		public int[,] tetr1 = new int[4, 4]
		{
			{0, 0, 1, 0},
			{0, 0, 1, 0},
			{0, 0, 1, 0},
			{0, 0, 1, 0},
		};
		public int[,] tetr2 = new int[3, 3]
		{
			{0, 0, 0},
			{2, 2, 0},
			{0, 2, 2},
		};
		public int[,] tetr3 = new int[3, 3]
		{
			{0, 0, 0},
			{0, 3, 3},
			{3, 3, 0},
		};
		public int[,] tetr4 = new int[3, 3]
		{
			{0, 0, 0},
			{4, 4, 4},
			{0, 4, 0},
		};
		public int[,] tetr5 = new int[3, 3]
		{
			{5, 0, 0},
			{5, 0, 0},
			{5, 5, 0},
		};
		public int[,] tetr6 = new int[3, 3]
		{
			{0, 0, 6},
			{0, 0, 6},
			{0, 6, 6},
		};
		public int[,] tetr7 = new int[2, 2]
		{
			{7, 7},
			{7, 7},
		};
		public Shape(int x, int y)
		{
			this.x = x;
			this.y = y;
			matrix = GenerateMatrix();
			sizeMatrix = (int)Math.Sqrt(matrix.Length);
			nextMatrix = GenerateMatrix();
			sizeNextMatrix = (int)Math.Sqrt(nextMatrix.Length);
		}
		public void ResetShape(int x, int y)
        {
			this.x = x;
			this.y = y;
			matrix = nextMatrix;
			sizeMatrix = (int)Math.Sqrt(matrix.Length);
			nextMatrix = GenerateMatrix();
			sizeNextMatrix = (int)Math.Sqrt(nextMatrix.Length);
		}
		public int[,] GenerateMatrix()
        {
			int[,] _matrix = tetr1;
			Random rand = new Random();
			switch (rand.Next(1, 8))
            {
				case 1:
					_matrix = tetr1;
					break;
				case 2:
					_matrix = tetr2;
					break;
				case 3:
					_matrix = tetr3;
					break;
				case 4:
					_matrix = tetr4;
					break;
				case 5:
					_matrix = tetr5;
					break;
				case 6:
					_matrix = tetr6;
					break;
				case 7:
					_matrix = tetr7;
					break;
			}
			return _matrix;
		}
		public void RotateShape(int dir)
        {
			int[,] tempMatrix = new int [sizeMatrix, sizeMatrix];
            for (int i = 0; i < sizeMatrix; i++)
            {
                for (int j = 0; j < sizeMatrix; j++)
                {
					if(dir== 1)
						tempMatrix[i, j] = matrix[j, (sizeMatrix - 1)-i];
                    else
                    {
						tempMatrix[j, (sizeMatrix - 1) - i] = matrix[i, j];
					}
                }
            }
			matrix = tempMatrix;
			int offset1 = (8 - (x + sizeMatrix));
			if(offset1 < 0)
            {
                for (int i = 0; i < Math.Abs(offset1); i++)
                {
					MoveLeft();
                }
            }
			int offset2 = (0 - (x + sizeMatrix));
			if (x < 0)
			{
				for (int i = 0; i < Math.Abs(x)+1; i++)
				{
					MoveRight();
				}
			}
		}
		public void MoveDowm() => y++;
		public void MoveRight() => x++;
		public void MoveLeft() => x--;
	}
}
