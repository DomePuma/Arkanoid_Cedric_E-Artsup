using UnityEngine;
using ScoreObserverPattern;

namespace BrickBreaker.Brick.Type
{
    public class StandardBrick : ABrick
    {
        [SerializeField] protected int _hitPoints = 1;

        //Test de l'observer sans d�truire les bricks parce que la balle n'est pas encore impl�ment�e
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