using UnityEngine;

namespace BrickBreaker.Utils
{
    public class ScreenBoundsSystem : MonoBehaviour
    {
        [SerializeField] private ScreenBoundsData _boundsData;

        public static float MinX { get; private set; }
        public static float MaxX { get; private set; }
        public static float MinY { get; private set; }
        public static float MaxY { get; private set; }

        private void Awake()
        {
            if (_boundsData == null)
            {
                Debug.LogError("ScreenBoundsData not assigned in ScreenBoundsManager.");
                return;
            }

            MinX = _boundsData.minX;
            MaxX = _boundsData.maxX;
            MinY = _boundsData.minY;
            MaxY = _boundsData.maxY;
        }
    }
}