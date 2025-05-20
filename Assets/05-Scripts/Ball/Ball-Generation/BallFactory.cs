using UnityEngine;
using System.Collections.Generic;
using BrickBreaker.Ball.Type;

namespace BrickBreaker.Ball.Factory
{
    public class BallFactory
    {
        private static GameObject _baseBallPrefab;
        private static GameObject _multiBallPrefab;

        public static void Initialize(BallFactoryData config)
        {
            _baseBallPrefab = config.BaseBallPrefab;
            _multiBallPrefab = config.MultiBallPrefab;
        }

        public static void CreateBrick(BallType type, Vector3 position)
        {
            GameObject prefab = null;

            switch (type)
            {
                case BallType.Base:
                    prefab = _baseBallPrefab;
                    break;

                case BallType.Multi:
                    prefab = _multiBallPrefab;
                    break;
            }

            if (prefab == null)
            {
                Debug.LogError("No prefab found for type: " + type);
                return;
            }

            Object.Instantiate(prefab, position, Quaternion.identity);
            return;
        }
    }
}