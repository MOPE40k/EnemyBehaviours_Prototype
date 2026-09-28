using _Project.Develop.CharactersCore;
using UnityEngine;

namespace _Project.Develop.Features.BehaviourFeatures
{
    public abstract class MovableBehaviour : IBehaviour
    {
        // References
        private readonly CharacterControllerBase _character = null;

        protected MovableBehaviour(CharacterControllerBase character)
            => _character = character;

        // References
        protected CharacterControllerBase Character => _character;

        public void Update()
        {
            Vector3 moveDirection = CalculateMoveDirection();

            Vector3 normalizedDirection = moveDirection.normalized;

            _character.MovementController.SetDirection(normalizedDirection);
            _character.AnimationController.MovementAnimate(normalizedDirection);
        }
        
        protected abstract Vector3 CalculateMoveDirection();
    }
}