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

    // Find 썼어요 생각없이 코드 썼어요 니들이 뭘 할수 있는데요 ㅋ
    IEnumerator FindEnemy()
    {
        ColorEnemy[] arr = GameObject.FindObjectsOfType<ColorEnemy>();

        yield return new WaitForSeconds(3);
    }
}
