using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GateAppearence : MonoBehaviour
{
    [Header("Gate Icon Settings")]
    [SerializeField] private GameObject _expandLabel;
    [SerializeField] private GameObject _shrinkLabel;
    [SerializeField] private GameObject _upLabel;
    [SerializeField] private GameObject _downLabel;
    [Header("Gate Image Settings")]
    [SerializeField] private Image _topImage;
    [SerializeField] private Image _glassImage;
    [SerializeField][Range(0, 1)] private float _glassAlpha = 0.5f;
    [SerializeField] private Color _colorPositive;
    [SerializeField] private Color _colorNegative;
    [Header("Value Settings")]
    [SerializeField] private TextMeshProUGUI _text;

    public void UpdateVisual(DeformationType deformationType, int value)
    {
        string prefix = "";

        if (value > 0)
        {
            prefix = "+";

            SetColor(_colorPositive);
        }
        else if (value == 0)
        {
            SetColor(Color.grey);
        }
        else
        {
            SetColor(_colorNegative);
        }

        _text.text = prefix + value.ToString();

        _expandLabel.SetActive(false);
        _shrinkLabel.SetActive(false);
        _upLabel.SetActive(false);
        _downLabel.SetActive(false);

        if (deformationType == DeformationType.Width)
        {
            if (value > 0)
            {
                _expandLabel.SetActive(true);
            }
            else
            {
                _shrinkLabel.SetActive(true);
            }
        }
        else if (deformationType == DeformationType.Height)
        {
            if (value > 0)
            {
                _upLabel.SetActive(true);
            }
            else
            {
                _downLabel.SetActive(true);
            }
        }
    }

    private void SetColor(Color color)
    {
        _topImage.color = color;
        _glassImage.color = new Color(color.r, color.g, color.b, _glassAlpha);
    }
}

public enum DeformationType
{
    Width,
    Height
}
