using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    
    public void Shoot()
    {
        var rot = this.transform.rotation;
        rot.x += 90;
        transform.TransformDirection(transform.forward);
        Instantiate(_bullet, this.transform.position, this.transform.rotation); 
    }
}
