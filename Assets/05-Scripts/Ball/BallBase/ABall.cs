using BrickBreaker.Utils;
using UnityEngine;

namespace BrickBreaker.Ball.Base
{
    [RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
    public abstract class ABall : MonoBehaviour
    {
        [Header("Ball Settings")]
        [SerializeField] protected float _speed = 5f;
        [SerializeField] protected string _playerTag = "Player";

        protected Vector2 _direction = Vector2.up;

        private void Update()
        {
            Move();
            HandleScreenBounce();
        }

        private void Move()
        {
            transform.position += (Vector3)(_direction * _speed * Time.deltaTime);
        }

        private void HandleScreenBounce()
        {
            Vector2 pos = transform.position;

            if (pos.x <= ScreenBoundsSystem.MinX || pos.x >= ScreenBoundsSystem.MaxX)
            {
                _direction.x *= -1;
                pos.x = Mathf.Clamp(pos.x, ScreenBoundsSystem.MinX, ScreenBoundsSystem.MaxX);
            }

            if (pos.y >= ScreenBoundsSystem.MaxY)
            {
                _direction.y *= -1;
                pos.y = ScreenBoundsSystem.MaxY;
            }

            if (pos.y <= ScreenBoundsSystem.MinY)
            {
                Death();
                return;
            }

            transform.position = pos;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag(_playerTag))
            {
                ReflectFromPaddle(collider);
            }
            else if (collider.CompareTag("Brick") || collider.CompareTag("Wall"))
            {
                ReflectFromObject(collider);
            }
        }

        private void ReflectFromPaddle(Collider2D paddle)
        {
            Vector2 ballPos = transform.position;
            Vector2 paddlePos = paddle.transform.position;
            float paddleWidth = paddle.bounds.size.x;

            float offset = (ballPos.x - paddlePos.x) / (paddleWidth / 2f);
            _direction = new Vector2(offset, 1).normalized;
        }

        private void ReflectFromObject(Collider2D obj)
        {
            Vector2 normal = (transform.position - obj.transform.position).normalized;
            _direction = Vector2.Reflect(_direction, normal).normalized;
        }

        public abstract void Death();
    }
}