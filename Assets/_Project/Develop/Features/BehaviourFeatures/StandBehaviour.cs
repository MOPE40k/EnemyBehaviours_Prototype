using _Project.Develop.CharactersCore;
using _Project.Develop.Utils;
using UnityEngine;

namespace _Project.Develop.Features.BehaviourFeatures
{
    public sealed class StandBehaviour : MovableBehaviour
    {
        // Consts
        private const float DistanceThreshold = 0.1f;

        // References
        private readonly DistanceChecker _distanceChecker = null;

        // Runtime
        private readonly Vector3 _startingPosition = Vector3.zero;

        public StandBehaviour(CharacterControllerBase character) : base(character)
        {
            _startingPosition = character.transform.position;

            _distanceChecker = new DistanceChecker(DistanceThreshold);
        }

        protected override Vector3 CalculateMoveDirection()
        {
            Vector3 pointA = _startingPosition;
            pointA.y = 0f;

            Vector3 pointB = Character.transform.position;
            pointB.y = 0f;

            if (_distanceChecker.IsCloseEnough(pointA, pointB))
                return Vector3.zero;

            Vector3 resultDirection = pointA - pointB;

            return resultDirection;
        }
    }
}