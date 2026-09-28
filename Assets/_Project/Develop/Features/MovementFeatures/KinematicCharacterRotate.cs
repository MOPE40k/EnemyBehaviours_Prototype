using UnityEngine;

namespace _Project.Develop.Features.MovementFeatures
{
    public class KinematicCharacterRotate : IRotatable
    {
        // Settings
        private readonly float _rotationSpeed = 0f;
        
        // References
        private readonly Rigidbody _rigidbody = null;
        

        public KinematicCharacterRotate(Rigidbody rigidbody, float rotationSpeed)
        {
            _rigidbody = rigidbody;
            _rotationSpeed = rotationSpeed;
        }

        public void RotateTo(Vector3 direction)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            float delta = _rotationSpeed * Time.deltaTime;

            Quaternion rotation = Quaternion.RotateTowards(_rigidbody.rotation, targetRotation, delta);

            _rigidbody.MoveRotation(rotation);
        }
    }
}