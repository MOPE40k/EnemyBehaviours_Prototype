using System;
using _Project.Develop.Features.InputFeatures;
using UnityEngine;

namespace _Project.Develop.CharactersCore
{
    public sealed class PlayerCharacterController : CharacterControllerBase
    {
        // References
        private IInputSource _input = null;

        // Runtime
        private Vector3 _moveDirection = Vector3.zero;

        private void Awake()
            => _input = new InputSystemReader();

        private void OnEnable()
            => _input.Enable();

        private void OnDisable()
            => _input.Disable();

        private void Update()
        {
            _moveDirection = _input.MoveAxes;

            MovementController.SetDirection(_moveDirection);
            AnimationController.MovementAnimate(_moveDirection);
        }
    }
}