using UnityEngine;

namespace BrickBreaker.Ball.Base
{
    public abstract class ABall : MonoBehaviour
    {
        public float speed;

        public abstract void Hit(Collision2D collision);
    }
}
