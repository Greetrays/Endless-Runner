using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    [SerializeField] private UnityEvent _hit;

    public event UnityAction Hit
    {
        add => _hit.AddListener(value);
        remove => _hit.RemoveListener(value);
    }

    public int Health => _health;

    public void ApplayDamage(int damage)
    {
        _health -= damage;
        _hit?.Invoke();

        if (_health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {

    }
}
