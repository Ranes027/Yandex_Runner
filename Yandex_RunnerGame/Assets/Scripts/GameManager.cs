using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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

    }

    public void ShowFinishWindow()
    {
        _finishWindow.SetActive(true);
    }

    public void NextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel < SceneManager.sceneCountInBuildSettings)
        {
            _collectibleManager.SaveToProgress();

            SceneManager.LoadScene(nextLevel);
        }
    }
}
