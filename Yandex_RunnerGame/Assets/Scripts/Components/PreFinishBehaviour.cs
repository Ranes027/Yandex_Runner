using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFinishBehaviour : MonoBehaviour
{
    [SerializeField] private float _finishRunSpeed = 3f;
    [SerializeField] private float _changePositionSpeed = 2f;
    [SerializeField] private float _changeAngleSpeed = 100f;

    private void Update()
    {
        CenterRunPosition();
        CenterAnglePosition();
    }

    private void CenterRunPosition()
    {
        float x = Mathf.MoveTowards(transform.position.x, 0, Time.deltaTime * _changePositionSpeed);
        float z = transform.position.z + _finishRunSpeed * Time.deltaTime;
        transform.position = new Vector3(x, 0, z);
    }

    private void CenterAnglePosition()
    {
        float rot = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 0, Time.deltaTime * _changeAngleSpeed);
        transform.localEulerAngles = new Vector3(0, rot, 0);
    }
}
