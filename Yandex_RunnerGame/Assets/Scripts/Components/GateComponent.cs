using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateComponent : MonoBehaviour
{
    [SerializeField] private GateAppearence _gateAppearence;
    [SerializeField] private DeformationType _deformationType;
    [SerializeField] private int _value;

    private void OnValidate()
    {
        _gateAppearence.UpdateVisual(_deformationType, _value);
    }
}
