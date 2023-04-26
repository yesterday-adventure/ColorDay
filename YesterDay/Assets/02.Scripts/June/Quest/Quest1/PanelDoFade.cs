using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PanelDoFade : MonoBehaviour
{
    Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        image.color = new Color(0.05f, 0.05f, 0.05f, 0);
        image.DOFade(0.7f, 0.5f);
    }
}
