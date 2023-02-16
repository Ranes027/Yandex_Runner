using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _startMenu;

    [SerializeField] private TextMeshProUGUI _levelName;

    private void Start()
    {
        _levelName.text = SceneManager.GetActiveScene().name;
    }

    public void StartGame()
    {
        _startMenu.SetActive(false);

        FindObjectOfType<PlayerBehaviour>().Play();

    }
}
