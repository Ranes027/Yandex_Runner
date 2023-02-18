using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartStoryMode()
    {
        SceneManager.LoadScene(Progress.Instance.PlayerInfo.Level + 1);
    }
}
