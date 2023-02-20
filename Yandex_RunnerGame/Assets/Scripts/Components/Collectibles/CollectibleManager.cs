using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class CollectibleManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void AddCoinsExtern();

    [SerializeField] private TextMeshProUGUI _valueText;
    [SerializeField] private GameObject _advButton;

    public int NumberOfCollectibles;

    private void Start()
    {
        NumberOfCollectibles = Progress.Instance.PlayerInfo.Coins;
        _valueText.text = NumberOfCollectibles.ToString();
        transform.parent = null;
    }

    public void AddOne()
    {
        NumberOfCollectibles++;
        _valueText.text = NumberOfCollectibles.ToString();
    }

    public void SaveToProgress()
    {
        Progress.Instance.PlayerInfo.Coins = NumberOfCollectibles;
    }

    public void SpendMoney(int value)
    {
        NumberOfCollectibles -= value;
        _valueText.text = NumberOfCollectibles.ToString();
    }

    public void ShowAdvButton()
    {
        AddCoinsExtern();
        _advButton.SetActive(false);
    }

    public void AddCoins()
    {
        NumberOfCollectibles *= 2;
        _valueText.text = NumberOfCollectibles.ToString();
        SaveToProgress();
    }
}
