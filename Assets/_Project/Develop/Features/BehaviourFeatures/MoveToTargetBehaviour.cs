using _Project.Develop.CharactersCore;
using UnityEngine;

namespace _Project.Develop.Features.BehaviourFeatures
{
    public sealed class MoveToTargetBehaviour : MovableBehaviour
    {
        // References
        private readonly Transform _target = null;

        public MoveToTargetBehaviour(CharacterControllerBase character, Transform target) : base(character)
            => _target = target;

        protected override Vector3 CalculateMoveDirection()
        {
            Vector3 resultDirection = _target.position - Character.transform.position;

            return resultDirection;
        }
    }
}