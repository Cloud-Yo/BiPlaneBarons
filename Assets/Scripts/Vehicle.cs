using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{
    [SerializeField] protected float _speed = 2.5f;
    public float Speed { get { return _speed; } set { _speed = value; } }
    protected string _name;
    public string Name { get { return _name; } set { _name = value; } }
    public abstract void Move();
}
