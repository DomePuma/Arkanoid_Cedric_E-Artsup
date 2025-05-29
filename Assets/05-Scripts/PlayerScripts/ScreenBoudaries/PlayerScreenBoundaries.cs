using BrickBreaker.Utils;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerScreenBoundaries : MonoBehaviour
    {
        private float _halfWidth;

        private void Awake()
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            _halfWidth = spriteRenderer.bounds.extents.x;
        }

        private void FixedUpdate()
        {
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, ScreenBoundsSystem.MinX + _halfWidth, ScreenBoundsSystem.MaxX - _halfWidth);
            transform.position = pos;
        }
    }
}