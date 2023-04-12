using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public SpriteRenderer SpriteRenderer
    {
        get
        {
            if (_spriteRenderer == null)
                _spriteRenderer = GetComponent<SpriteRenderer>();
            return _spriteRenderer;
        }
    }

    public void GenerateColor()
    {
        SpriteRenderer.color = Random.ColorHSV();
    }

    public void ResetColor()
    {
        SpriteRenderer.color = Color.white;
    }
}
