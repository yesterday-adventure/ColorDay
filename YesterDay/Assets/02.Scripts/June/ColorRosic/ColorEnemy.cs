using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEnemy : MonoBehaviour
{
    [Header("���ʹ� �⺻ �Ӽ�")]
    [SerializeField] protected ColorEnum dieColor = ColorEnum.white;
    [SerializeField] protected ColorEnum currentColor;
    [SerializeField] protected float power = 3f;
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected float attackSpeed = 1f;
}