using UnityEngine;

namespace _Project.Develop.Features.MovementFeatures
{
    public class KinematicCharacterMove : IMovable
    {
        // Settings
        private readonly float _moveSpeed = 0f;
        
        // References
        private readonly Rigidbody _rigidbody = null;

        public KinematicCharacterMove(Rigidbody rigidbody, float moveSpeed)
        {
            _rigidbody = rigidbody;
            _moveSpeed = moveSpeed;
        }

        public void MoveTo(Vector3 direction)
        {
            Vector3 delta = _rigidbody.position + direction * _moveSpeed * Time.deltaTime;

            _rigidbody.MovePosition(delta);
        }
    }
}