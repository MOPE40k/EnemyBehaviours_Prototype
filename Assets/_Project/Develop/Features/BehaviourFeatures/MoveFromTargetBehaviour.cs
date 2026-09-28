using _Project.Develop.CharactersCore;
using UnityEngine;

namespace _Project.Develop.Features.BehaviourFeatures
{
    public sealed class MoveFromTargetBehaviour : MovableBehaviour
    {
        // References
        private readonly Transform _target = null;

        public MoveFromTargetBehaviour(CharacterControllerBase character, Transform target) : base(character)
            => _target = target;

        protected override Vector3 CalculateMoveDirection()
        {
            Vector3 resultDirection = Character.transform.position - _target.position;

            return resultDirection;
        }
    }
}