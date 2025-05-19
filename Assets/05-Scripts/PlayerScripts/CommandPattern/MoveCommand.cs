using UnityEngine;

namespace PlayerCommand
{
    public class MoveCommand : Command
    {
        private Transform _playerTransform;
        private float _speed;
        private Vector3 _direction;

        public MoveCommand(Transform playerTransform, float speed, Vector3 direction)
        {
            _playerTransform = playerTransform;
            _speed = speed;
            _direction = direction.normalized;
        }

        public override void Execute()
        {
            _playerTransform.position += _direction * _speed * Time.deltaTime;
        }
    }
}