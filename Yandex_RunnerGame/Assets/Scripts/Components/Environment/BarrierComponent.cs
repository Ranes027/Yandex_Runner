using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierComponent : MonoBehaviour
{   
    [SerializeField] int _barrierDamage;

    private void OnTriggerEnter(Collider other)
    {
        PlayerModifier playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();

        if(playerModifier != null)
        {
            playerModifier.HitBarrier(_barrierDamage);
            Destroy(gameObject);
        }
    }
}
