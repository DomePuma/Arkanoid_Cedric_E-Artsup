using UnityEngine;

namespace BrickBreaker.Brick.Type
{
    public class UnbreakableBrick : ABrick
    {
        [SerializeField] private int _scoreOnDestroyed = 1000;

        public override void Hit()
        {
            Debug.Log("This brick is unbreakable.");
        }
    }
}