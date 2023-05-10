using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpSlider : MonoBehaviour
{
    [SerializeField]
    private Slider hpSlider;

    private void Awake()
    {
        hpSlider = GetComponent<Slider>();
    }

    public void ChangeHPSlider_Float(float percent)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeSliderRoutine(percent));
    }

    private IEnumerator ChangeSliderRoutine(float percent)
    {
        float end = 0;
        while (true)
        {
            end += 0.01f;
            yield return new WaitForSeconds(0.01f);
            //Debug.Log(end);
            hpSlider.value = Mathf.Lerp(hpSlider.value, percent, end);
            if (end > 1)
            {
                break;
            }
        }
        yield return null;
    }
}
