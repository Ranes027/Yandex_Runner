using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();

    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _finishWindow;

    [SerializeField] private TextMeshProUGUI _levelName;

    [SerializeField] private CollectibleManager _collectibleManager;

    private void Start()
    {        
        _levelName.text = SceneManager.GetActiveScene().name;
    }

    public void StartGame()
    {
        _startMenu.SetActive(false);
        FindObjectOfType<PlayerBehaviour>().Play();

        Progress.Instance.Save();
    }

    public void ShowFinishWindow()
    {
        _finishWindow.SetActive(true);
        ShowAdv();
    }

    public void NextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel < SceneManager.sceneCountInBuildSettings)
        {
            _collectibleManager.SaveToProgress();

            Progress.Instance.PlayerInfo.Level = SceneManager.GetActiveScene().buildIndex;

            Progress.Instance.Save();
            SceneManager.LoadScene(nextLevel);
        }
    }
}
