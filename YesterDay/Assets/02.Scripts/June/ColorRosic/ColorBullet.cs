using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBullet : MonoBehaviour
{
    [Header("불렛 기본 속성")]
    [SerializeField] private ColorEnum bulletColor = ColorEnum.white;
    public ColorEnum BulletColor => bulletColor;
    [SerializeField] private float power = 3f;
    public float Power => power;
    [SerializeField] private float speed = 3f;
}