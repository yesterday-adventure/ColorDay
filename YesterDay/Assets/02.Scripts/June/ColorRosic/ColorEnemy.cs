using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEnemy : MonoBehaviour
{
    [Header("에너미 기본 속성")]
    [SerializeField] protected ColorEnum dieColor = ColorEnum.white;
    [SerializeField] public ColorEnum currentColor;
    [SerializeField] protected float power = 3f;
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected float attackSpeed = 1f;

    [Header("에너미 색")]
    [SerializeField] GameObject colorSphere;
    [SerializeField] GameObject bodyColor;

    MeshRenderer f = null;
    SkinnedMeshRenderer b = null;
    
    protected virtual void OnEnable()
    {
        f = colorSphere.GetComponent<MeshRenderer>();
        f.material = ColorManager.instance.colorMaterials[(int)dieColor];

        b = bodyColor.GetComponent<SkinnedMeshRenderer>();
        b.material = ColorManager.instance.GhostcolorMaterials[(int)currentColor];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            ColorBullet color = other.GetComponent<ColorBullet>();

            if (color.BulletColor == ColorEnum.white)
            {
                currentColor = ColorManager.instance.ChangeWhite();
            }
            currentColor = ColorManager.instance.AddColor(currentColor, color.BulletColor);
            b.material = ColorManager.instance.GhostcolorMaterials[(int)currentColor];
            if (ColorManager.instance.CheckColor(dieColor, currentColor))
                gameObject.SetActive(false);
        }
    }

    public void ChangeWhite()
    {
        currentColor = ColorManager.instance.ChangeWhite();
        b.material = ColorManager.instance.GhostcolorMaterials[(int)currentColor];
    }
}