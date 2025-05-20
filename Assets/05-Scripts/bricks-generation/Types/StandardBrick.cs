using UnityEngine;

namespace BrickBreaker.Brick.Type
{
    public class StandardBrick : ABrick
    {
        [SerializeField] protected int _hitPoints = 1;

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
            Destroy(gameObject);
        }
    }
}