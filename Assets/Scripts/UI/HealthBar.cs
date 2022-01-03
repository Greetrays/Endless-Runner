using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthBar;
    [SerializeField] private Player _playerHealth;

    private void Start()
    {
        _healthBar.text = _playerHealth.Health.ToString();
        _playerHealth.Hit += UpdateBar;
    }

    private void UpdateBar()
    {
        _healthBar.text = _playerHealth.Health.ToString();
    }
}
