using UnityEngine;

namespace BrickBreaker.Ball.Base
{
    public abstract class ABall : MonoBehaviour
    {
        [SerializeField] protected float _speed;
        [SerializeField] protected string _playerTag;

        private Vector2 _currentDirection = Vector2.up;

        private void FixedUpdate()
        {
            gameObject.transform.Translate(_currentDirection * _speed * Time.deltaTime);
        }

        private void Hit(Collision2D collision)
        {
            if (collision.gameObject.tag == _playerTag)
            {
                _currentDirection = new Vector2(HitRacketPart(transform.position, collision.transform.position, collision.collider.bounds.size), 1f).normalized;

            }
            else
            {
                _currentDirection = Vector2.Reflect(_currentDirection, collision.contacts[0].normal);
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
