using System.Collections.Generic;
using UnityEngine;

namespace BrickBreaker.Brick.Factory
{
    [CreateAssetMenu(fileName = "BrickFactoryData", menuName = "Scriptable Object/Brick FactoryData")]
    public class BrickFactoryData : ScriptableObject
    {
        [SerializeField] private List<GameObject> _standardBrickPrefabList;
        [SerializeField] private List<GameObject> _bonusBrickPrefabList;
        [SerializeField] private GameObject _unbreakableBrickPrefab;

        public List<GameObject> StandardBrickPrefabList => _standardBrickPrefabList;
        public List<GameObject> BonusBrickPrefabList => _bonusBrickPrefabList;
        public GameObject UnbreakableBrickPrefab => _unbreakableBrickPrefab;
    }
}