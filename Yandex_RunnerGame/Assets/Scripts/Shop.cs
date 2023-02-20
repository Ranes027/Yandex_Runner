using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private CollectibleManager _collectibleManager;
    [Header("Prices")]
    [SerializeField] private int _widthPrice = 5;
    [SerializeField] private int _heightPrice = 5;
    [Header("Stats Value")]
    [SerializeField] private int _widthValue = 20;
    [SerializeField] private int _heightValue = 20;
    [Header("Stats Text")]
    [SerializeField] private TextMeshProUGUI _widthText;
    [SerializeField] private TextMeshProUGUI _heightText;

    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value);

    private PlayerModifier _playerModifier;

    private void Start()
    {
        _playerModifier = FindObjectOfType<PlayerModifier>();

        UpdatePricesInUI();
    }

    public void BuyWidth()
    {
        if (_collectibleManager.NumberOfCollectibles >= _widthPrice)
        {
            _collectibleManager.SpendMoney(_widthPrice);
            Progress.Instance.PlayerInfo.Coins = _collectibleManager.NumberOfCollectibles;
            Progress.Instance.PlayerInfo.Width += _widthValue;

            _playerModifier.SetWidth(Progress.Instance.PlayerInfo.Width);
        }
    }

    public void BuyHeight()
    {
        if (_collectibleManager.NumberOfCollectibles >= _heightPrice)
        {
            _collectibleManager.SpendMoney(_heightPrice);
            Progress.Instance.PlayerInfo.Coins = _collectibleManager.NumberOfCollectibles;
            Progress.Instance.PlayerInfo.Height += _heightValue;

            SetToLeaderboard(Progress.Instance.PlayerInfo.Height);

            _playerModifier.SetHeight(Progress.Instance.PlayerInfo.Height);
        }
    }

    private void UpdatePricesInUI()
    {
        _widthText.text = _widthPrice.ToString();
        _heightText.text = _heightPrice.ToString();
    }
}
