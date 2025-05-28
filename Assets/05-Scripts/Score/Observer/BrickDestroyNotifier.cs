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

        public void NotifyBrickDestroyed()
        {
            NotifyObservers();
        }
    }
}