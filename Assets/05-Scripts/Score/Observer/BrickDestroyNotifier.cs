using UnityEngine;

namespace BrickBreaker.BrickDestroyed.Subject
{
    public class BrickDestroyNotifier : ObserverSubject
    {
        public static BrickDestroyNotifier Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        [ContextMenu("Notification For Brick Destroyed")]
        public void NotifyBrickDestroyed(Vector3 position, int score)
        {
            NotifyObservers(position, score);
        }
    }
}