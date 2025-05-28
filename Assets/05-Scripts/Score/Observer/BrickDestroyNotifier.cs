using UnityEngine;

namespace BrickBreaker.Score.Subject
{
    public class BrickDestroyNotifier : ObserverSubject
    {
        public static BrickDestroyNotifier Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        [ContextMenu("Send Notification")]
        public void NotifyBrickDestroyed()
        {
            NotifyObservers();
        }
    }
}