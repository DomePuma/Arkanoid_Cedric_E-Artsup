using BrickBreaker.Utils;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerScreenBoundaries : MonoBehaviour
    {
        private float _halfWidth;
        private bool _screenBoundsWarningLogged = false;

        private void Awake()
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            _halfWidth = spriteRenderer.bounds.extents.x;
        }

        private void FixedUpdate()
        {
            if (!_screenBoundsWarningLogged && (ScreenBoundsSystem.MinX == 0f && ScreenBoundsSystem.MaxX == 0f))
            {
                Debug.LogWarning("ScreenBoundsSystem semble ne pas être configuré ou initialisé correctement (MinX = MaxX = 0).");
                _screenBoundsWarningLogged = true;
            }

            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, ScreenBoundsSystem.MinX + _halfWidth, ScreenBoundsSystem.MaxX - _halfWidth);
            transform.position = pos;
        }
    }
}