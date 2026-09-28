using _Project.Develop.CharactersCore;
using _Project.Develop.Utils;
using UnityEngine;

namespace _Project.Develop.Features.BehaviourFeatures
{
    public sealed class MoveToRandomDirectionBehaviour : MovableBehaviour
    {
        // Settings
        private readonly float _moveAreaRadius = 5;
        private readonly float _toggleDirectionInterval = 5f;

        // References
        private Timer _timer = null;

        // Runtime
        private Vector3 _startingPosition = Vector3.zero;
        private Vector3 _currentDirection = Vector3.zero;

        public MoveToRandomDirectionBehaviour(CharacterControllerBase character, float radius, float toggleDirectionInterval) : base(character)
        {
            _moveAreaRadius = radius;
            _toggleDirectionInterval = toggleDirectionInterval;

            _startingPosition = character.transform.position;

            _timer = new Timer();

            _currentDirection = GetRandomDirection();
        }

        protected override Vector3 CalculateMoveDirection()
        {
            if (_timer.Time >= _toggleDirectionInterval)
            {
                _timer.DecrementTimerBy(_toggleDirectionInterval);

                _currentDirection = GetRandomDirection();
            }

            _timer.IncrementTimerBy(Time.deltaTime);

            Vector3 resultDirection = _currentDirection - Character.transform.position;

            return resultDirection;
        }

        private Vector3 GetRandomDirection()
        {
            Vector3 randomPoint = Random.insideUnitSphere.normalized;
            randomPoint.y = 0;
            randomPoint *= _moveAreaRadius;

            return _startingPosition + randomPoint;
        }
    }
}