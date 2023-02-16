using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierComponent : MonoBehaviour
{   
    [SerializeField] int _barrierDamage;

    [SerializeField] GameObject _bricksEffectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        PlayerModifier playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();

        if(playerModifier != null)
        {
            playerModifier.HitBarrier(_barrierDamage);
            Destroy(gameObject);

            Instantiate(_bricksEffectPrefab, transform.position, transform.rotation);
        }
    }
}
