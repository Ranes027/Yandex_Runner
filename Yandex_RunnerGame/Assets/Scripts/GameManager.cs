using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _startMenu;

    public void StartGame()
    {
        _startMenu.SetActive(false);

        FindObjectOfType<PlayerBehaviour>().Play();

    }
}
