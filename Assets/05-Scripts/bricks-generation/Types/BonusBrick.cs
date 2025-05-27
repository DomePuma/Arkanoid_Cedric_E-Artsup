using UnityEngine;

namespace BrickBreaker.Brick.Type
{
    public class BonusBrick : StandardBrick
    {
        [SerializeField] private GameObject _bonusPrefab;

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