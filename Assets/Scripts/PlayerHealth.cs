using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health = 100;
    private PlayerDeath _playerDeath;
    public int Health { get { return _health; } set { _health = value; } }

    void Start()
    {
        _playerDeath = GetComponent<PlayerDeath>();
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health < 0)
        {
            _playerDeath.OnplayerDeath();
        }
    }
}
