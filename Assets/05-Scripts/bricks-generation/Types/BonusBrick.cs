using UnityEngine;
using ScoreObserverPattern;

namespace BrickBreaker.Brick.Type
{
    public class BonusBrick : StandardBrick
    {
        [SerializeField] private GameObject _bonusPrefab;

        //Test de l'observer sans détruire les bricks parce que la balle n'est pas encore implémentée
        private void Start()
        {
            BrickDestroyNotifier.Instance?.NotifyBrickDestroyed(); // Notify score
        }

        protected override void OnDestroyBrick()
        {
            if (_bonusPrefab != null)
            {
                Instantiate(_bonusPrefab, transform.position, Quaternion.identity);
            }

            base.OnDestroyBrick();
        }
    }
}