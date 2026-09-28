using System;
using _Project.Develop.CharactersCore;
using _Project.Develop.Features.BehaviourFeatures;
using UnityEngine;

namespace _Project.Develop.Features.SpawnFeatures
{
    public class SpawnPoint : MonoBehaviour
    {
        [Header("Behaviours Settings:")]
        [SerializeField] private BehaviourTypes _idleBehaviour = BehaviourTypes.StandBehaviour;
        [SerializeField] private BehaviourTypes _detectBehaviour = BehaviourTypes.MoveFromTargetBehaviour;

        [Space]
        [Header("Patrol To Waypoints Settings:")]
        [SerializeField] private Transform[] _patrolWaypoints = null;

        [Space]
        [Header("Move To Random Direction Settings:")]
        [SerializeField] private float _areaRadius = 5f;
        [SerializeField] private float _toogleDirectionTimeInterval = 1f;

        [Space]
        [Header("References:")]
        [SerializeField] private EnemyCharacterController _enemyPrefab = null;
        [SerializeField] private PlayerCharacterController _playerOnScene = null;
        [SerializeField] private ParticleSystem _explosionEffectPrefab = null;

#if UNITY_EDITOR
        [Space]
        [Header("ON DRAW GIZMOS SETTINGS:")]
        [SerializeField] private Color _gizmosColor = Color.red;
#endif

        // References
        private EnemyCharacterController _enemyInstance = null;

        private void Awake()
        {
            _enemyInstance = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

            IBehaviour idleBehaviour = GetBehaviour(_idleBehaviour);
            IBehaviour detectBehaviour = GetBehaviour(_detectBehaviour);

            _enemyInstance.Init(idleBehaviour, detectBehaviour);
        }

        private IBehaviour GetBehaviour(BehaviourTypes behaviour)
            => behaviour switch
            {
                BehaviourTypes.StandBehaviour
                    => new StandBehaviour(_enemyInstance),

                BehaviourTypes.PatrolToWaypointsBehaviour
                    => new PatrolToWaypointsBehaviour(_enemyInstance, _patrolWaypoints),

                BehaviourTypes.MoveToRandomDirectionBehaviour
                    => new MoveToRandomDirectionBehaviour(_enemyInstance, _areaRadius, _toogleDirectionTimeInterval),

                BehaviourTypes.MoveFromTargetBehaviour
                    => new MoveFromTargetBehaviour(_enemyInstance, _playerOnScene.transform),

                BehaviourTypes.MoveToTargetBehaviour
                    => new MoveToTargetBehaviour(_enemyInstance, _playerOnScene.transform),

                BehaviourTypes.SelfDestroyBehaviour
                    => new SelfDestroyBehaviour(_enemyInstance, _enemyInstance.ParticlesPoint, _explosionEffectPrefab),

                _
                    => throw new ArgumentOutOfRangeException("Unknown behaviour type!")
            };

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (_idleBehaviour != BehaviourTypes.MoveToRandomDirectionBehaviour)
                return;

            Gizmos.color = _gizmosColor;
            Gizmos.DrawWireSphere(transform.position, _areaRadius);
        }
#endif
    }
}