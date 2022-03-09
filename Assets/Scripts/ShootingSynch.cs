using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShootingSynch : MonoBehaviour, IPunObservable
{

    private ParticleSystem _shootingParticleSystem;
    public bool IsShooting  = false;
    [SerializeField] private float _shotDelay = 0.25f;
    private float _nextShot = 0f;
    private bool _canShoot => _nextShot < Time.time;
    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(IsShooting);
        }
        else
        {
            this.IsShooting = (bool)stream.ReceiveNext();
        }

    }

    // Start is called before the first frame update
    void Start()
    {

        _shootingParticleSystem = GetComponent<ParticleSystem>();   
    }

    public void Shoot()
    {
        IsShooting = true;
    }

    public void StopShooting()
    {
        IsShooting=false;
    }

    private void Update()
    {
        if(!_canShoot)
        {
            return;
        }
        if(IsShooting)
        {
            _shootingParticleSystem.Emit(1);
            _nextShot = _shotDelay + Time.time;
        }
    }
}
