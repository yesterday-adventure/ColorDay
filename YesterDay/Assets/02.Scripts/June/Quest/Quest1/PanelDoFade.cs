using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PanelDoFade : MonoBehaviour
{
    static public PanelDoFade instance;
    Image image;

    private void Awake()
    {
        instance = this;
        image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        image.color = new Color(0.05f, 0.05f, 0.05f, 0);
        image.DOFade(0.7f, 2f);
    }
    public void On()
    {
        image.DOFade(0f, 0f);
    }    
}
