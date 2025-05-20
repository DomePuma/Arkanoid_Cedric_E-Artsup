using UnityEngine;
using System.Collections.Generic;

namespace BrickBreaker.Brick.Factory
{
    public static class BrickFactory
    {
        private static List<GameObject> _standardPrefabs;
        private static List<GameObject> _bonusPrefabs;
        private static Dictionary<BrickType, GameObject> _singlePrefabMap;
        private static Transform _container;

        public static void Initialize(BrickFactoryData config, Transform container)
        {
            _standardPrefabs = config.StandardBrickPrefabList;
            _bonusPrefabs = config.BonusBrickPrefabList;

            _singlePrefabMap = new Dictionary<BrickType, GameObject>
        {
            { BrickType.Unbreakable, config.UnbreakableBrickPrefab },
        };

            _container = container;
        }

        public static GameObject CreateBrick(BrickType type, Vector3 position, int index = -1)
        {
            GameObject prefab = null;

            switch (type)
            {
                case BrickType.Standard:
                    prefab = GetPrefabByIndex(_standardPrefabs, index);
                    break;

                case BrickType.Bonus:
                    prefab = GetPrefabByIndex(_bonusPrefabs, index);
                    break;

                default:
                    _singlePrefabMap.TryGetValue(type, out prefab);
                    break;
            }

            if (prefab == null)
            {
                Debug.LogError("No prefab found for type: " + type);
                return null;
            }

            GameObject brick = Object.Instantiate(prefab, position, Quaternion.identity);
            if (_container != null)
                brick.transform.parent = _container;
            return brick;
        }

        private static GameObject GetPrefabByIndex(List<GameObject> prefabs, int index)
        {
            if (prefabs == null || prefabs.Count == 0)
            {
                Debug.LogError("Prefab list is empty or not assigned.");
                return null;
            }

            if (index >= 0 && index < prefabs.Count)
                return prefabs[index];

            return prefabs[Random.Range(0, prefabs.Count)];
        }
    }
}