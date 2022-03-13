using SpaceShipWarBa.Abstracts.Controllers;
using SpaceShipWarBa.Abstracts.DataContainers;
using SpaceShipWarBa.Abstracts.Sounds;
using UnityEngine;

namespace SpaceShipWarBa.Sounds
{
    public class AudioSourceSoundPlayer : ICharacterSoundPlayer
    {
        readonly AudioSource _audioSource;
        readonly ICharacterStats _stats;

        public AudioSourceSoundPlayer(IEntityController entityController, ICharacterStats stats)
        {
            _audioSource = entityController.transform.GetComponent<AudioSource>();
            _stats = stats;
        }
        
        public void LaserSound()
        {
            _audioSource.PlayOneShot(_stats.LaserSound);
        }

        public void DeadSound()
        {
            AudioSource.PlayClipAtPoint(_stats.DeadSound,_audioSource.transform.position);
        }

        public void TakeHitSound()
        {
            _audioSource.PlayOneShot(_stats.TakeHitSound);
        }
    }
    
    public class FmodSoundPlayer : ICharacterSoundPlayer
    {
        public FmodSoundPlayer(IEntityController entity, ICharacterStats stats)
        {
            
        }
        
        public void LaserSound()
        {
            throw new System.NotImplementedException();
        }

        public void DeadSound()
        {
            throw new System.NotImplementedException();
        }

        public void TakeHitSound()
        {
            throw new System.NotImplementedException();
        }
    }
}