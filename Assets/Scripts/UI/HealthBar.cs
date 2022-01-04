using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Heart _heartPrefab;
    [SerializeField] private Player _player;

    private List<Heart> _hearts = new List<Heart>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged()
    {
        if (_hearts.Count < _player.Health && _player.Health > 0)
        {
            int countHealth = _player.Health - _hearts.Count;

            for (int i = 0; i < countHealth; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > _player.Health && _player.Health > 0)
        {
            int countHealth = _hearts.Count - _player.Health;

            for (int i = 0; i < countHealth; i++)
            {
                DestroyHeart(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void DestroyHeart(Heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heartPrefab, transform);
        _hearts.Add(newHeart.GetComponent<Heart>());
        newHeart.ToFill();
    }
}
