using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(FindEnemy());
    }

    // Find ���� �������� �ڵ� ���� �ϵ��� �� �Ҽ� �ִµ��� ��
    IEnumerator FindEnemy()
    {
        ColorEnemy[] arr = GameObject.FindObjectsOfType<ColorEnemy>();

        yield return new WaitForSeconds(3);
    }
}
