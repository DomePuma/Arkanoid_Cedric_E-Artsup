using UnityEngine;

namespace BrickBreaker.Brick.Factory
{
    public class BrickFactoryInitializer : MonoBehaviour
    {
        [SerializeField] private BrickFactoryData _brickFactoryDataInstance;

        private void Awake()
        {
            BrickFactory.Initialize(_brickFactoryDataInstance, transform);
        }
    }
}