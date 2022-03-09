using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    private Transform _bulletTransform;

    void Start()
    {
        _bulletTransform = transform;
        Destroy(this.gameObject, 3f);
    }


    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
