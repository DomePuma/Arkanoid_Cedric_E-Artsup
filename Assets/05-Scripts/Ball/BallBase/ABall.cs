using UnityEngine;

namespace BrickBreaker.Ball.Base
{
    public abstract class ABall : MonoBehaviour
    {
        [SerializeField] protected float _speed;
        [SerializeField] protected int _playerLayer;
        
        protected Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        private void Start()
        {
            _rigidbody2D.linearVelocity = Vector2.up * _speed;
        }

        private void Hit(Collision2D collision)
        {
            if (collision.gameObject.layer == _playerLayer) //faudra changer ça en le vrai Layer du joueur
            {
                Debug.Log("");
                Vector2 directionNormalized = new Vector2(HitRacketPart(transform.position, collision.transform.position, collision.collider.bounds.size), 1f).normalized;
                _rigidbody2D.linearVelocity = directionNormalized * _speed;

            }
        }
        private float HitRacketPart(Vector2 ballPos, Vector2 racketPos, Vector2 racketWidth)
	    {
		    return (ballPos.x - racketPos.x) / racketWidth.x;
	    }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Hit(collision);
        }

        public abstract void Death();
    }
}
