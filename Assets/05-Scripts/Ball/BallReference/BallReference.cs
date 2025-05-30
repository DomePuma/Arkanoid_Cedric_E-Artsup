using UnityEngine;

namespace BrickBreaker.Ball
{
    public static class BallReference
    {
        public static Transform BallTransform { get; private set; }

        public static void RegisterBall(Transform ballTransform)
        {
            BallTransform = ballTransform;
        }
    }
}
