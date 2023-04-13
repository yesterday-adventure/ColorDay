using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : ColorEnemy
{
    int[] arr = { 1, 6, 10, 7, 11, 16, 12, 21, 22, 26, 8, 13 };

    protected override void OnEnable()
    {
        currentColor = ColorEnum.white;
        dieColor = (ColorEnum)arr[Random.Range(0, arr.Length)];
        base.OnEnable();
    }

    private void OnDisable()
    {
        if (gameObject.activeSelf == false && TutorialObject.instance != null)
            TutorialObject.instance.Resurrection(this.gameObject);
    }
}