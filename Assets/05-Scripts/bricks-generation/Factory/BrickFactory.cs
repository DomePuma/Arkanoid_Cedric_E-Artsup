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

        public static GameObject CreateBrick(BrickType type, Vector3 position)
        {
            GameObject prefab = null;

            switch (type)
            {
                case BrickType.Standard:
                    prefab = GetRandomPrefab(_standardPrefabs);

                    if (_standardPrefabs == null || _standardPrefabs.Count == 0)
                    {
                        Debug.LogError("No standard brick prefabs configured.");
                        return null;
                    }
                    break;

                case BrickType.Bonus:
                    prefab = GetRandomPrefab(_bonusPrefabs);

                    if (_bonusPrefabs == null || _bonusPrefabs.Count == 0)
                    {
                        Debug.LogError("No bonus brick prefabs configured.");
                        return null;
                    }
                    break;

                default:
                    _singlePrefabMap.TryGetValue(type, out prefab);

                    if (!_singlePrefabMap.TryGetValue(type, out prefab) || prefab == null)
                    {
                        Debug.LogError("No prefab for type: " + type);
                        return null;
                    }
                    break;
            }

            GameObject brick = Object.Instantiate(prefab, position, Quaternion.identity);
            if (_container != null)
                brick.transform.parent = _container;
            return brick;
        }

        private static GameObject GetRandomPrefab(List<GameObject> prefabs)
        {
            if (prefabs == null || prefabs.Count == 0)
            {
                Debug.LogError("Prefab list is empty or not assigned.");
                return null;
            }

            return prefabs[Random.Range(0, prefabs.Count)];
        }
    }
}