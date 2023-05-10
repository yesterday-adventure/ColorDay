using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHpSliderTest : MonoBehaviour
{
    public UnityEvent<float> ChangeHp;

    public void ChangeHP(float percent)
    {
        ChangeHp?.Invoke(percent);
    }
}
