using BrickBreaker.Ball.Base;
using UnityEngine;

namespace BrickBreaker.Ball.Type
{
    public class BallBase : ABall
    {
        public override void Death()
        {
            // Notifie PlayerHealth de la perte d’une vie
            FindFirstObjectByType<PlayerHealth>().LoseLife();

            Destroy(gameObject);
        }
    }
}