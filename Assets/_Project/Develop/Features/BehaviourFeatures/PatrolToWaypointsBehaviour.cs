using _Project.Develop.CharactersCore;
using _Project.Develop.Utils;
using UnityEngine;

namespace _Project.Develop.Features.BehaviourFeatures
{
    public sealed class PatrolToWaypointsBehaviour : MovableBehaviour
    {
        // Consts
        private const float _distanceThreshold = 0.5f;

        // References
        private readonly Transform[] _waypoints = null;
        private readonly DistanceChecker _distanceChecker = null;

        // Runtime
        private int _currentWaypointIndex = 0;

        public PatrolToWaypointsBehaviour(CharacterControllerBase character, Transform[] waypoints) : base(character)
        {
            _waypoints = waypoints;

            _distanceChecker = new DistanceChecker(_distanceThreshold);
        }

        protected override Vector3 CalculateMoveDirection()
        {
            Vector3 pointA = _waypoints[_currentWaypointIndex].position;
            pointA.y = 0f;

            Vector3 pointB = Character.transform.position;
            pointB.y = 0f;

            if (_distanceChecker.IsCloseEnough(pointA, pointB))
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;

            Vector3 resultDirection = pointA - pointB;

            return resultDirection;
        }
    }
}