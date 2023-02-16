using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMove;

    private void Start()
    {
        _playerMove.enabled = false;
    }

    public void Play()
    {
        _playerMove.enabled = true;
    }
}
