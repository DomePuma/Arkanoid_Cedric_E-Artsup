using UnityEngine;

namespace BrickBreaker.Brick.Type
{
    public class StandardBrick : ABrick
    {
        [SerializeField] protected int _hitPoints = 1;

        private void Start()
        {
            BrickDestroyNotifier.Instance?.NotifyBrickDestroyed(); // Notify score
        }

        public override void Hit()
        {
            _hitPoints--;

            if (_hitPoints <= 0)
            {
                OnDestroyBrick();
            }
        }

        protected virtual void OnDestroyBrick()
        {
            BrickDestroyNotifier.Instance?.NotifyBrickDestroyed(); // Notify score
            Destroy(gameObject);
        }
    }
}