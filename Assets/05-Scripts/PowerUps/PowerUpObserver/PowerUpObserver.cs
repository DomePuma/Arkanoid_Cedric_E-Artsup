using BrickBreaker.BrickDestroyed.Subject;
using BrickBreaker.Spawning.PowerUp;
using UnityEngine;

namespace BrickBreaker.BrickDestroyed.Observer
{
    public class PowerUpObserver : MonoBehaviour, IBrickDestroyedObserver
    {
        [SerializeField] private ObserverSubject _brickDestroyNotifier;
        [SerializeField] private PowerUpSpawner _powerUpSpawner;

        private void OnEnable()
        {
            _brickDestroyNotifier.AddObserver(this);
        }

        private void OnDisable()
        {
            _brickDestroyNotifier.RemoveObserver(this);
        }

        public void OnNotify(Vector3 brickPosition, int scoreOnBrickDestroyed)
        {
            _powerUpSpawner.SpawnPowerUp(brickPosition);
        }
    }
}