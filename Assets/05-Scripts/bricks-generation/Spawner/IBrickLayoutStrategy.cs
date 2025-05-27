using BrickBreaker.Brick;

namespace BrickBreaker.Spawning.Layout
{
    public interface IBrickLayoutStrategy
    {
        BrickType[,] GenerateLayout(int rows, int columns);
    }
}