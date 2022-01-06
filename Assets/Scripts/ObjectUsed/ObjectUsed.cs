using UnityEngine;

public abstract class ObjectUsed : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        gameObject.SetActive(false);
    }
}
