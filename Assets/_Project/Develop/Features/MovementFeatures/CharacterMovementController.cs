using UnityEngine;

namespace _Project.Develop.Features.MovementFeatures
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterMovementController : MonoBehaviour
    {
        // Consts
        private const float Deadzone = 0.05f;

        [Header("Settings")]
        [SerializeField] private float _moveSpeed = 2f;
        [SerializeField] private float _rotationSpeed = 250f;

        // References
        private Rigidbody _rigidbody = default;
        private IMovable _move = default;
        private IRotatable _rotate = default;

        // Runtime
        private Vector3 _moveDirection = default;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _move = new KinematicCharacterMove(_rigidbody, _moveSpeed);
            _rotate = new KinematicCharacterRotate(_rigidbody, _rotationSpeed);
        }

        private void FixedUpdate()
        {
            if (_moveDirection.sqrMagnitude < Deadzone * Deadzone)
                return;

            var normalizedDirection = _moveDirection.normalized;

            MoveTo(normalizedDirection);
            RotateTo(normalizedDirection);
        }

        public void SetDirection(Vector3 moveDirection)
            => _moveDirection = moveDirection;

        private void MoveTo(Vector3 direction)
            => _move.MoveTo(direction);

        private void RotateTo(Vector3 direction)
            => _rotate.RotateTo(direction);
    }
}