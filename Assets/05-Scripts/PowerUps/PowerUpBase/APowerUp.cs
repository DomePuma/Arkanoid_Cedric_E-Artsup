using UnityEngine;

namespace BrickBreaker.PowerUp.Base
{
    public abstract class APowerUp : MonoBehaviour
    {
        [Header("PowerUp Settings")]
        [SerializeField] private float _speed = 5f;

        private void Update()
        {
            transform.position += Vector3.down * _speed * Time.deltaTime;
        }

        public abstract void OnClaim();
    }
}