using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBullet : MonoBehaviour
{
    [Header("불렛 기본 속성")]
    [SerializeField] private ColorEnum bulletColor = ColorEnum.white;
    public ColorEnum BulletColor
    {
        get { return bulletColor; }
        set { bulletColor = value; }
    }
    [SerializeField] private float power = 3f;
    public float Power => power;
}