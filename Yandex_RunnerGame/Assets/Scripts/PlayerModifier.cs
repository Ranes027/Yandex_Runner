using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModifier : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;

    [SerializeField] private Renderer _renderer;

    [SerializeField] private Transform _topSpine;
    [SerializeField] private Transform _bottomSpine;

    [SerializeField] private Transform _colliderTransform;

    private float _widthMultiplier = 0.0005f;
    private float _heightMultiplier = 0.01f;

    private void Update()
    {
        float offsetY = _height * _heightMultiplier + 0.17f;
        _topSpine.position = _bottomSpine.position + new Vector3(0, offsetY, 0);
        _colliderTransform.localScale = new Vector3(1, 1.85f + _height * _heightMultiplier, 1);
    }

    public void AddWidth(int value)
    {
        _width += value;
        _renderer.material.SetFloat("_PushValue", _width * _widthMultiplier);
    }

    public void AddHeight(int value)
    {
        _height += value;
    }
}
