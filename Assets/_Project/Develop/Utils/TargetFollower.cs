using UnityEngine;

namespace _Project.Develop.Utils
{
    public class TargetFollower : MonoBehaviour
    {
        [Header("Settings:")] [SerializeField] private bool _followXAxis = true;
        [SerializeField] private bool _followYAxis = true;
        [SerializeField] private bool _followZAxis = false;

        [Header("References:")] [SerializeField]
        private Transform _target = null;

        // Runtime
        private Vector3 _offset = Vector3.zero;

        private void Awake()
            => _offset = transform.position - _target.position;

        private void LateUpdate()
            => CalculatePosition();

        private void CalculatePosition()
        {
            var newPosition = transform.position;

            newPosition.x = _followXAxis 
                ? _target.position.x + _offset.x 
                : transform.position.x;
            
            newPosition.y = _followYAxis 
                ? _target.position.y + _offset.y 
                : transform.position.y;
            
            newPosition.z = _followZAxis 
                ? _target.position.z + _offset.z 
                : transform.position.z;

            transform.position = newPosition;
        }
    }
}