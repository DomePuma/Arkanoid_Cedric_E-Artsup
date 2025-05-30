using BrickBreaker.Ball.Factory;
using BrickBreaker.Ball.Type;
using UnityEngine;

namespace BrickBreaker.Ball.Spawner
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private BallType _ballType;
        [SerializeField] private Transform _ballSpwanPoint;

        public void SpawnBall()
        {
            BallFactory.CreateBall(_ballType, _ballSpwanPoint.position);
        }
    }
}