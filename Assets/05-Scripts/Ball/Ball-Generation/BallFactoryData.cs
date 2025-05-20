using UnityEngine;

namespace BrickBreaker.Ball.Factory
{
    [CreateAssetMenu(fileName = "BallFactoryData", menuName = "Scriptable Object/Ball FactoryData")]
    public class BallFactoryData : ScriptableObject
    {
        [SerializeField] private GameObject _baseBallPrefab;
        [SerializeField] private GameObject _multiBallPrefab;

        public GameObject BaseBallPrefab => _baseBallPrefab;
        public GameObject MultiBallPrefab => _multiBallPrefab;
    }
}
