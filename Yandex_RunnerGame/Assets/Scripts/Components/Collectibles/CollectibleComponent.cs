using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleComponent : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 180;

    void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<CollectibleManager>().AddOne();
        Destroy(gameObject);
    }
}
