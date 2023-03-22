using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class TestEnemy : ColorEnemy
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerBullet"))
        {
            ColorBullet color = other.GetComponent<ColorBullet>();

            if(color.BulletColor == ColorEnum.white )
            {
                currentColor = ColorManager.instance.ChangeWhite();
            }
            currentColor = ColorManager.instance.AddColor(currentColor, color.BulletColor);
            if (ColorManager.instance.CheckColor(dieColor, currentColor))
                Destroy(gameObject);
        }
    }
}