using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : ObjectUsed
{
    [SerializeField] private int _count;

    public int Count => _count;

}
