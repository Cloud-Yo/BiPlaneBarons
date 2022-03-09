using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleCamera : MonoBehaviour
{
    private Transform _transform = null;
    private Camera _mainCam;
    void Start()
    {
        _transform = transform;
        _mainCam = Camera.main;

    }


}
