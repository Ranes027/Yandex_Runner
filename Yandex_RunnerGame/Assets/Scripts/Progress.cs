using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int Level;

    public int Coins;
    public int Width;
    public int Height;
}

public class Progress : MonoBehaviour
{
    public PlayerInfo PlayerInfo;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    [SerializeField] private TextMeshProUGUI _playerInfoText;

    public static Progress Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);

            Instance = this;
            LoadExtern();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //временно, для сброса прогресса в черновике
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            PlayerInfo = new PlayerInfo();
            Save();
        }
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);

        SaveExtern(jsonString);
    }

    public void SetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        _playerInfoText.text = PlayerInfo.Coins + "\n" + PlayerInfo.Width + "\n" + PlayerInfo.Height + "\n" + PlayerInfo.Level;

    }
}
