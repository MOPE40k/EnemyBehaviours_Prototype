using UnityEngine;

namespace _Project.Develop.Features.AnimationFeatutes
{
    public class CharacterAnimationController : MonoBehaviour
    {
        // Consts
        private const float Deadzone = 0.05f;
        private const string IsRunningKey = "IsRunning";

        [Header("References:")] [SerializeField]
        private Animator _animator = null;

        public void MovementAnimate(Vector3 direction)
        {
            bool isRunning = direction.sqrMagnitude > Deadzone;

            _animator.SetBool(IsRunningKey, isRunning);
        }
    }
}