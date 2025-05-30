using UnityEngine;
using BrickBreaker.Ball.Type;
using BrickBreaker.Ball;

namespace BrickBreaker.Ball.Factory
{
    public static class BallFactory
    {
        private static GameObject _baseBallPrefab;
        private static GameObject _multiBallPrefab;

        public static void Initialize(BallFactoryData config)
        {
            _baseBallPrefab = config.BaseBallPrefab;
            _multiBallPrefab = config.MultiBallPrefab;
        }

        public static void CreateBall(BallType type, Vector3 position)
        {
            GameObject prefab = type switch
            {
                BallType.Multi => _multiBallPrefab,
                _ => _baseBallPrefab
            };

            if (prefab == null)
            {
                Debug.LogError("No prefab found for type: " + type);
                return;
            }

            GameObject newBall = Object.Instantiate(prefab, position, Quaternion.identity);

            BallReference.RegisterBall(newBall.transform);
        }
    }
}
