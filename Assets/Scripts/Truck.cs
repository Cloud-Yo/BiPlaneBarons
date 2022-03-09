using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour, IDamageable
{
    public int Health { get { return _health; } set { _health = value; } }
    [SerializeField] private int _health = 3;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
