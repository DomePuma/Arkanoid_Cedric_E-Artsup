using UnityEngine;

namespace BrickBreaker.BrickDestroyed.Observer
{
    public interface IBrickDestroyedObserver
    {
        public void OnNotify(Vector3 brickPosition, int scoreOnBrickDestroyed);
    }
}