using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private UnityEvent _refill;

    public event UnityAction Refill
    {
        add => _refill.AddListener(value);
        remove => _refill.RemoveListener(value);
    }

    public int Money { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Money money))
        {
            Money += money.Count;
            _refill?.Invoke();
        }
    }
}
