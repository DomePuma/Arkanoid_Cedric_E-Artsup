using UnityEngine;

namespace BrickBreaker.Ball.Factory
{
    public class BallFactoryInitialize : MonoBehaviour
    {
        [SerializeField] private BallFactoryData _ballFactoryData;

        private void Awake()
        {
            BallFactory.Initialize(_ballFactoryData);
        }
    }
}