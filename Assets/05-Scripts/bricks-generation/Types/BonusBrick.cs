using UnityEngine;

namespace BrickBreaker.Brick.Type
{
    public class BonusBrick : StandardBrick
    {
        [SerializeField] private GameObject _bonusPrefab;

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