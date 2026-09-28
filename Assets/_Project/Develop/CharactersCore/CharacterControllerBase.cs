using _Project.Develop.Features.AnimationFeatutes;
using _Project.Develop.Features.MovementFeatures;
using UnityEngine;

namespace _Project.Develop.CharactersCore
{
    public abstract class CharacterControllerBase : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private CharacterMovementController _movementController = null;
        [SerializeField] private CharacterAnimationController _animationController = null;

        // References
        public CharacterMovementController MovementController => _movementController;
        public CharacterAnimationController AnimationController => _animationController;
    }
}