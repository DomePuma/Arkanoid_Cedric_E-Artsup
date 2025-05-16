using UnityEngine;
using BrickBreaker.Brick.Factory;
using BrickBreaker.Brick;

namespace BrickBreaker.Spawning
{
    public class BrickSpawner : MonoBehaviour
    {
        [Header("Layout Configuration")]
        [SerializeField] private int _rows = 6;
        [SerializeField] private int _columns = 13;
        [SerializeField] private Vector2 _startOffset = new Vector2(-6f, 4f);
        [SerializeField] private float _brickHeight = 0.5f;
        [SerializeField] private float _brickWidth = 1f;

        private IBrickLayoutStrategy _layoutStrategy;

        private void Awake()
        {
            _layoutStrategy = new ArkanoidLayoutStrategy();
        }

        private void Start()
        {
            SpawnBricks();
        }

        private void SpawnBricks()
        {
            BrickType[,] layout = _layoutStrategy.GenerateLayout(_rows, _columns);

            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _columns; col++)
                {
                    BrickType type = layout[row, col];

                    if (type == BrickType.Standard || type == BrickType.Unbreakable || type == BrickType.Bonus)
                    {
                        Vector3 position = new Vector3(
                            _startOffset.x + col * _brickWidth,
                            _startOffset.y - row * _brickHeight,
                            0f
                        );

                        BrickFactory.CreateBrick(type, position);
                    }
                }
            }
        }
    }
}