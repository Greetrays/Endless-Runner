using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyBar;
    [SerializeField] private PlayerMoney _playerMoney;

    private void OnEnable()
    {
        _playerMoney.Refill += UpdateBar;
    }

    private void OnDisable()
    {
        _playerMoney.Refill -= UpdateBar;
    }

    private void UpdateBar()
    {
        _moneyBar.text = _playerMoney.Money.ToString();
    }
}
