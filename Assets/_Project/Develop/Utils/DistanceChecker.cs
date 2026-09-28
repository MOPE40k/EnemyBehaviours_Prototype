using UnityEngine;

namespace _Project.Develop.Utils
{
    public class DistanceChecker
    {
        // Settings
        private readonly float _distanceThreshold = 0f;

        public DistanceChecker(float distanceThreshold)
            => _distanceThreshold = distanceThreshold;

        public bool IsCloseEnough(Vector3 pointA, Vector3 pointB)
        {
            float distance = (pointA - pointB).sqrMagnitude;

            return distance <= _distanceThreshold * _distanceThreshold;
        }
    }
}