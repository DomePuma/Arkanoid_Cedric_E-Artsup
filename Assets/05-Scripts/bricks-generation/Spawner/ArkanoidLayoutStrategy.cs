using BrickBreaker.Brick;
using BrickBreaker.Spawning;

namespace BrickBreaker.Spawning.Layout
{
    public class ArkanoidLayoutStrategy : IBrickLayoutStrategy
    {
        public BrickType[,] GenerateLayout(int rows, int columns)
        {
            BrickType[,] layout = new BrickType[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (row == 0)
                        layout[row, col] = BrickType.Unbreakable;
                    else if (row == 1 || row == 2)
                        layout[row, col] = BrickType.Bonus;
                    else
                        layout[row, col] = BrickType.Standard;
                }
            }

            return layout;
        }
    }
}