using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bulletSystem = null;
    [SerializeField] private GameObject _hitFX = null;
    List<ParticleCollisionEvent> _hitEvents = new List<ParticleCollisionEvent>();

    private void OnParticleCollision(GameObject other)
    {
        int events = _bulletSystem.GetCollisionEvents(other, _hitEvents);

        for (int i = 0; i < events; i++)
        {
            IDamageable dam = other.GetComponent<IDamageable>();
            if(dam != null)
            {
                dam.TakeDamage(15);
            }
            
            GameObject hit = Instantiate(_hitFX, _hitEvents[i].intersection, Quaternion.LookRotation(_hitEvents[i].normal));
            
        }

    }

}
