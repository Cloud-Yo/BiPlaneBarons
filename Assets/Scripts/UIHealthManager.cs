using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthManager : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    private PlayerHealth _playerHealth;


    void Start()
    {
        _healthBar.fillAmount = 1;
        this.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (_playerHealth != null)
        {
            UpdateHealthBar();
        }
    }

    private void UpdateHealthBar()
    {
        float fill = _playerHealth.Health / 100f;
        _healthBar.fillAmount = fill;
        if(fill <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void SetPlayer(PlayerHealth ph)
    {
        _playerHealth = ph;
    }
}
