using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject[] _playerGameObjects;

    public void OnplayerDeath()
    {
        foreach (var obj in _playerGameObjects)
        {
            obj.SetActive(false);
        }
    }
}
