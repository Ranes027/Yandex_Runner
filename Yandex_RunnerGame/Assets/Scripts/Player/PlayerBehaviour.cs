using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMove;
    [SerializeField] private PreFinishBehaviour _preFinishBehaviour;
    [Space]
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _playerMove.enabled = false;
        _preFinishBehaviour.enabled = false;
    }

    public void Play()
    {
        _playerMove.enabled = true;
    }

    public void StartPreFinishBehaviour()
    {
        _playerMove.enabled = false;
        _preFinishBehaviour.enabled = true;
    }

    public void StartFinishBehaviour()
    {
        _preFinishBehaviour.enabled = false;
        _animator.SetTrigger("Dance");
    }
}
