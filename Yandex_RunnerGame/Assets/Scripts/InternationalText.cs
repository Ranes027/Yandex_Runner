using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InternationalText : MonoBehaviour
{
    [SerializeField] private string _en;
    [SerializeField] private string _ru;

    private void Start()
    {
        if (Language.Instance.CurrentLanguage == "en")
        {
            GetComponent<TextMeshProUGUI>().text = _en;
        }
        else if (Language.Instance.CurrentLanguage == "ru")
        {
            GetComponent<TextMeshProUGUI>().text = _ru;
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = _en;
        }
    }
}
