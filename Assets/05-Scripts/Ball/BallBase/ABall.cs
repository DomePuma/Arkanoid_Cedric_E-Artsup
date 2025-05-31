using BrickBreaker.Brick;
using BrickBreaker.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BrickBreaker.Ball.Base
{
    [RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
    public abstract class ABall : MonoBehaviour
    {
        [Header("Ball Settings")]
        [SerializeField] protected float _speed = 5f;
        [SerializeField] protected string _playerTag = "Player";
        [SerializeField] private LayerMask _collisionMask;
        [SerializeField] private float _detectionRadius = 0.1f;

        protected Vector2 _direction = Vector2.up;

        private static readonly List<ABall> _allBalls = new List<ABall>();
        public static IReadOnlyList<ABall> AllBalls => _allBalls;

        private void OnEnable() => _allBalls.Add(this);
        private void OnDisable() => _allBalls.Remove(this);

        private void Update()
        {
            Move();
            HandleScreenBounce();
            DetectCollisions();

            // S'assure que la direction ne soit jamais trop horizontale
            if (Mathf.Abs(_direction.y) < 0.3f)
            {
                _direction.y = 0.3f * Mathf.Sign(_direction.y == 0 ? 1 : _direction.y);
                _direction = _direction.normalized;
            }
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

                if (Mathf.Abs(_direction.y) < 0.3f)
                {
                    _direction.y = 0.3f * Mathf.Sign(_direction.y == 0 ? 1 : _direction.y);
                }

                _direction = _direction.normalized;
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

        private void DetectCollisions()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _detectionRadius, _collisionMask);

            Vector2? dominantNormal = null;
            float maxDot = -1f;
            bool brickHit = false;

            foreach (Collider2D hit in hits)
            {
                if (hit.CompareTag(_playerTag))
                {
                    ReflectFromPaddle(hit);
                    return;
                }
            }

            foreach (Collider2D hit in hits)
            {
                if (hit.CompareTag("Brick"))
                {
                    ABrick brick = hit.GetComponent<ABrick>();
                    if (brick != null)
                    {
                        brick.Hit();
                        brickHit = true;

                        // Déterminer la meilleure direction pour rebondir
                        Vector2 toBall = ((Vector2)transform.position - (Vector2)hit.transform.position).normalized;
                        Vector2[] normals = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

                        foreach (Vector2 normal in normals)
                        {
                            float dot = Vector2.Dot(_direction, normal);
                            if (dot > maxDot)
                            {
                                maxDot = dot;
                                dominantNormal = normal;
                            }
                        }
                    }
                }
                else if (hit.CompareTag("Wall"))
                {
                    ReflectFromObject(hit);
                    return;
                }
            }

            // Après avoir géré toutes les briques touchées
            if (brickHit && dominantNormal.HasValue)
            {
                _direction = Vector2.Reflect(_direction, dominantNormal.Value).normalized;

                float noise = 0.05f;
                _direction += new Vector2(Random.Range(-noise, noise), Random.Range(-noise, noise));
                _direction.Normalize();

                // Évite les directions trop horizontales
                if (Mathf.Abs(_direction.y) < 0.3f)
                {
                    _direction.y = 0.3f * Mathf.Sign(_direction.y == 0 ? 1 : _direction.y);
                    _direction.Normalize();
                }
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
            Vector2 contactDirection = (Vector2)transform.position - (Vector2)obj.transform.position;
            Bounds bounds = obj.bounds;

            float dx = Mathf.Abs(contactDirection.x) - bounds.extents.x;
            float dy = Mathf.Abs(contactDirection.y) - bounds.extents.y;

            Vector2 normal;

            if (dx > dy)
            {
                normal = new Vector2(Mathf.Sign(contactDirection.x), 0);
            }
            else
            {
                normal = new Vector2(0, Mathf.Sign(contactDirection.y));
            }

            _direction = Vector2.Reflect(_direction, normal).normalized;

            /* Ajoute une petite variation aléatoire à la direction
            (ça permet d'éviter que la balle rebondisse de façon parfaitement verticale ou horizontale) */
            float noise = 0.1f;
            _direction += new Vector2(Random.Range(-noise, noise), Random.Range(-noise, noise));
            _direction = _direction.normalized;
        }

        public abstract void Death();
    }
}