using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ScreenBoundaries : MonoBehaviour
    {
        private float _playerHalfWidth;
        private float _playerHalfHeight;
        private Camera _mainCamera;

        private void Start()
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            _playerHalfWidth = spriteRenderer.bounds.extents.x;
            _playerHalfHeight = spriteRenderer.bounds.extents.y;
            _mainCamera = Camera.main;
        }

        private void FixedUpdate()
        {
            ClampPosition();
        }

        private void ClampPosition()
        {
            Vector3 position = transform.position;

            // Get screen bounds in the world
            float minX = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z - _mainCamera.transform.position.z)).x + _playerHalfWidth;
            float maxX = _mainCamera.ViewportToWorldPoint(new Vector3(1, 0, transform.position.z - _mainCamera.transform.position.z)).x - _playerHalfWidth;

            float minY = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z - _mainCamera.transform.position.z)).y + _playerHalfHeight;
            float maxY = _mainCamera.ViewportToWorldPoint(new Vector3(0, 1, transform.position.z - _mainCamera.transform.position.z)).y - _playerHalfHeight;

            // Clamp position with the sprite
            position.x = Mathf.Clamp(position.x, minX, maxX);
            position.y = Mathf.Clamp(position.y, minY, maxY);

            transform.position = position;
        }
    }
}
