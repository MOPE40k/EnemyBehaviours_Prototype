using _Project.Develop.Features.BehaviourFeatures;
using UnityEngine;

namespace _Project.Develop.CharactersCore
{
    public sealed class EnemyCharacterController : CharacterControllerBase
    {
        // References
        private IBehaviour _idleBehaviour = null;
        private IBehaviour _detectBehaviour = null;

        // Runtime
        private IBehaviour _currentBehaviour = null;

        private void Update()
        {
            if (_currentBehaviour == null)
            {
                Debug.LogError("Behaviour not set!");

                return;
            }

            _currentBehaviour.Update();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (IsPlayer(other) == false)
                return;

            SetBehaviour(_detectBehaviour);
        }

        private void OnTriggerExit(Collider other)
        {
            if (IsPlayer(other) == false)
                return;

            SetBehaviour(_idleBehaviour);
        }

        public void Init(IBehaviour idleBehaviour, IBehaviour detectBehaviour)
        {
            _idleBehaviour = idleBehaviour;
            _detectBehaviour = detectBehaviour;

            SetBehaviour(_idleBehaviour);
        }

        private void SetBehaviour(IBehaviour behaviour)
            => _currentBehaviour = behaviour;

        private bool IsPlayer(Collider collider)
            => collider.TryGetComponent<PlayerCharacterController>(out _);
    }
}