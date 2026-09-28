using _Project.Develop.CharactersCore;
using UnityEngine;

namespace _Project.Develop.Features.BehaviourFeatures
{
    public sealed class SelfDestroyBehaviour : IBehaviour
    {
        // References
        private readonly CharacterControllerBase _character = null;
        private readonly ParticleSystem _explosionEffectPrefab = null;

        public SelfDestroyBehaviour(CharacterControllerBase character, ParticleSystem explosionEffect)
        {
            _character = character;
            _explosionEffectPrefab = explosionEffect;
        }

        public void Update()
            => DoAction();

        private void DoAction()
        {
            GameObject.Instantiate(
                _explosionEffectPrefab,
                _character.transform.position,
                _explosionEffectPrefab.transform.rotation);

            GameObject.Destroy(_character.gameObject);
        }
    }
}