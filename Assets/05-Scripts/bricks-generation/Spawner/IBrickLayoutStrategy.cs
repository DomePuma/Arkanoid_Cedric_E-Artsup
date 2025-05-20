using BrickBreaker.Brick;

namespace BrickBreaker.Spawning
{
    public interface IBrickLayoutStrategy
    {
        BrickType[,] GenerateLayout(int rows, int columns);
    }
}