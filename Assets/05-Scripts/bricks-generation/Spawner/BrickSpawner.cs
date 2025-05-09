using UnityEngine;
using BrickBreaker.Brick.Factory;
using BrickBreaker.Brick;

namespace BrickBreaker.Spawning
{
    public class BrickSpawner : MonoBehaviour
    {
        [Header("Brick Layout")]
        [SerializeField] private int _rows = 5;
        [SerializeField] private int _columns = 10;

        private float _brickHeight = 0.5f;
        private Vector2 startOffset = new Vector2(-4.5f, 3f);

        private void Start()
        {
            SpawnBricks();
        }

        private void SpawnBricks()
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _columns; col++)
                {
                    Vector3 position = new Vector3(
                        startOffset.x + col,
                        startOffset.y - row * _brickHeight,
                        0f
                    );

                    BrickType type = GetBrickTypeForPosition(row, col);
                    BrickFactory.CreateBrick(type, position);
                }
            }
        }

        private BrickType GetBrickTypeForPosition(int row, int col)
        {
            if (row == 0) return BrickType.Unbreakable;
            return BrickType.Standard;
        }
    }
}