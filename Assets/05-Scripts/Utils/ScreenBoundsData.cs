using UnityEngine;

namespace BrickBreaker.Utils
{
    [CreateAssetMenu(fileName = "ScreenBoundsData", menuName = "Scriptable Object/Screen Bounds")]
    public class ScreenBoundsData : ScriptableObject
    {
        public float minX = -8f;
        public float maxX = 8f;
        public float minY = -5f;
        public float maxY = 4.5f;
    }
}