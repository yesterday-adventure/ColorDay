using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class TestEnemy : ColorEnemy
{
    [SerializeField] GameObject colorSphere;
    [SerializeField] GameObject bodyColor;

    private void OnEnable()
    {
        MeshRenderer f = colorSphere.GetComponent<MeshRenderer>();
        f.material = ColorManager.instance.colorMaterials[(int)dieColor];

        SkinnedMeshRenderer b = bodyColor.GetComponent<SkinnedMeshRenderer>();
        b.material = ColorManager.instance.GhostcolorMaterials[(int)currentColor];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Debug.Log(1);
            ColorBullet color = other.GetComponent<ColorBullet>();

            if (color.BulletColor == ColorEnum.white)
            {
                currentColor = ColorManager.instance.ChangeWhite();
            }
            currentColor = ColorManager.instance.AddColor(currentColor, color.BulletColor);
            if (ColorManager.instance.CheckColor(dieColor, currentColor))
                Destroy(gameObject);
        }
    }
}