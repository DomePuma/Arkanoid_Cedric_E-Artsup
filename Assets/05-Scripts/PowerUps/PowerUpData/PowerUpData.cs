using UnityEngine;
using BrickBreaker.PowerUp.Type;

namespace BrickBreaker.PowerUp.Data
{
    [CreateAssetMenu(fileName = "PowerUpData", menuName = "PowerUp/Create New PowerUp", order = 0)]
    public class PowerUpData : ScriptableObject
    {
        public PowerUpType powerUpType;
        public GameObject prefab;
        [Range(0f, 1f)]
        public float spawnChance = 0.1f;
    }
}
