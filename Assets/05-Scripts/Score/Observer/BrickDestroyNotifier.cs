using System;
using UnityEngine;

namespace BrickBreaker.Score.Subject
{
    public class BrickDestroyNotifier : ObserverSubject
    {
        public static BrickDestroyNotifier Instance { get; set; }

        public event Action OnAllBricksDestroyed;

        private int _totalBricks;
        private int _destroyedBricks;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void SetTotalDestructibleBricks(int count)
        {
            _totalBricks = count;
            _destroyedBricks = 0;
        }

        [ContextMenu("Add Score")]
        public void NotifyBrickDestroyed()
        {
            NotifyObservers();

            _destroyedBricks++;

            if (_destroyedBricks >= _totalBricks)
            {
                DestroyAllBricksForTest();
            }
        }

        [ContextMenu("Simulate Victory - Destroy All Bricks")]
        public void DestroyAllBricksForTest()
        {
            _destroyedBricks = _totalBricks;
            Debug.Log("All destructible bricks destroyed!");
            OnAllBricksDestroyed?.Invoke();
        }
    }
}