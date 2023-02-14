using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;

    void LateUpdate()
    {
        transform.position = _target.position;
    }
}
