using _Project.Develop.CharactersCore;
using UnityEngine;

namespace _Project.Develop.Features.BehaviourFeatures
{
    public sealed class SelfDestroyBehaviour : IBehaviour
    {
        // References
        private readonly CharacterControllerBase _character = default;
        private readonly Transform _particlePoint = default;
        private readonly ParticleSystem _explosionEffectPrefab = default;

        public SelfDestroyBehaviour(CharacterControllerBase character, Transform particlePoint, ParticleSystem explosionEffect)
        {
            _character = character;
            _particlePoint = particlePoint;
            _explosionEffectPrefab = explosionEffect;
        }

        public void Update()
            => DoAction();

        private void DoAction()
        {
            GameObject.Instantiate(
                _explosionEffectPrefab,
                _particlePoint.position,
                _explosionEffectPrefab.transform.rotation).Play();

            GameObject.Destroy(_character.gameObject);
        }
    }
}