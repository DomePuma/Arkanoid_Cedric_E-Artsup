using System;
using UnityEngine;

namespace BrickBreaker.PowerUp.Base
{
    public abstract class APowerUp : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] protected string _playerTag = "Player";

        private void Update()
        {
            transform.position += Vector3.down * _speed * Time.deltaTime;
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(_playerTag))
            {
                Claim();
                Destroy(gameObject);
            }
        }

        public abstract void Claim();
    }
}