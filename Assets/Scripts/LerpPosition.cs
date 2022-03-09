using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPosition : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;
    private Transform _transform;
    private Transform _camera;

    void Start()
    {
        _transform = transform;
        _camera = Camera.main.transform;  
    }


    void Update()
    {
        _transform.position = Vector3.Lerp(_transform.position, _target.position, _speed * Time.deltaTime);
        _transform.rotation = _camera.rotation;
    }
}
