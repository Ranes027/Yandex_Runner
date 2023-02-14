using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private int _numberOfCollectiblesInLevel;

    [SerializeField] private TextMeshProUGUI _valueText;

    public void AddOne()
    {
        _numberOfCollectiblesInLevel ++;
        _valueText.text = _numberOfCollectiblesInLevel.ToString();
    }
}
