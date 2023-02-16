using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _valueText;

    public int NumberOfCollectibles;

    private void Start()
    {
        NumberOfCollectibles = Progress.Instance.Coins;
        _valueText.text = NumberOfCollectibles.ToString();
    }

    public void AddOne()
    {
        NumberOfCollectibles++;
        _valueText.text = NumberOfCollectibles.ToString();
    }

    public void SaveToProgress()
    {
        Progress.Instance.Coins = NumberOfCollectibles;
    }

    public void SpendMoney(int value)
    {
        NumberOfCollectibles -= value;
        _valueText.text = NumberOfCollectibles.ToString();
    }
}
