using UnityEngine;

namespace BrickBreaker.Brick.Factory
{
    public class BrickFactoryInitializer : MonoBehaviour
    {
        [SerializeField] private BrickFactoryData _config;

        private void Awake()
        {
            BrickFactory.Initialize(_config, transform);
        }
    }
}