using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float _delay = 3f;
    void Start()
    {
        Destroy(this.gameObject, _delay);
    }

}
