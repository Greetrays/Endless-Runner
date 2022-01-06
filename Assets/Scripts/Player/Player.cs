using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private UnityEvent _hit;
    [SerializeField] private UnityEvent _usedMedicine;
    [SerializeField] private UnityEvent _usedShild;

    private bool _protected;
    
    public event UnityAction Died;
    public event UnityAction HealthChanged;

    public event UnityAction<float> UsedShild;

    public int Health { get; private set; }

    private void Start()
    {
        Health = _maxHealth;
        HealthChanged?.Invoke();
    }

    private void OnValidate()
    {
        if (_maxHealth <= 0)
        {
            _maxHealth = 5;
        }
    }

    public void ApplayDamage(int damage)
    {
        if (_protected == false)
        {
            Health -= damage;
            _hit?.Invoke();
            HealthChanged?.Invoke();
        }
        
        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Died?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
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
       
        if (other.TryGetComponent(out Shild shild))
        {
            SwitchProtected(true);
            UsedShild?.Invoke(shild.TimeAction);
            _usedShild?.Invoke();
        }
    }

    public void SwitchProtected(bool Protected)
    {
        _protected = Protected;
    }
}
