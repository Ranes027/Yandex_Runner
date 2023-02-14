using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private int _numberOfCollectiblesInLevel;

    public void AddOne()
    {
        _numberOfCollectiblesInLevel ++;
    }
}
