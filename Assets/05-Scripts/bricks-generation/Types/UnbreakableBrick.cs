using UnityEngine;

namespace BrickBreaker.Brick.Type
{
    public class UnbreakableBrick : IBrick
    {
        public override void Hit()
        {
            Debug.Log("This brick is unbreakable.");
        }
    }
}