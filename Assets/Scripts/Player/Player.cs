using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _hit;
    [SerializeField] private UnityEvent _usedMedicine;
    [SerializeField] private int _maxHealth;
    
    public event UnityAction Died;
    public event UnityAction HealthChanged;

    public int Health { get; private set; }

    private void Start()
    {
        HealthChanged?.Invoke();
    }

    private void OnValidate()
    {
        if (Health > _maxHealth || Health <= 0)
        {
            Health = _maxHealth;
        }

        if (_maxHealth <= 0)
        {
            _maxHealth = 5;
        }
    }

    public void ApplayDamage(int damage)
    {
        Health -= damage;
        _hit?.Invoke();
        HealthChanged?.Invoke();

        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Died?.Invoke();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Medicine medicine))
        {
            if (Health < _maxHealth)
            {
                Health += medicine.Count;
                HealthChanged?.Invoke();
            }

            _usedMedicine?.Invoke();
        }
    }
}
