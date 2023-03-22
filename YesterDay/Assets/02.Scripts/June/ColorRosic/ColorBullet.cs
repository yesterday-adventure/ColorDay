using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBullet : MonoBehaviour
{
    [Header("�ҷ� �⺻ �Ӽ�")]
    [SerializeField] private ColorEnum bulletColor = ColorEnum.white;
    public ColorEnum BulletColor => bulletColor;
    [SerializeField] private float power = 3f;
    public float Power => power;
    [SerializeField] private float speed = 3f;
}