using BrickBreaker.Ball.Base;
using UnityEngine;
using System;

namespace BrickBreaker.Ball.Type
{
    public class BallBase : ABall
    {
        public static event Action OnBallDeath;

        public override void Death()
        {
            OnBallDeath?.Invoke();

            Destroy(gameObject);
        }
    }
}