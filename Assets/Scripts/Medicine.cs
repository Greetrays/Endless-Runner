using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour
{
    [SerializeField] private int _count;

    public int Count => _count;

    private void OnTriggerEnter(Collider collision)
    {
        gameObject.SetActive(false);
    }
}
