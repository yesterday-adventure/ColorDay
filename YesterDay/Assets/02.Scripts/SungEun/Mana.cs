using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    [SerializeField]
    private Slider maneSlider;
    [SerializeField]
    private float maxMana = 20;
    [SerializeField]
    private float currentMana = 0;

    void Start()
    {
        maneSlider = GetComponent<Slider>();
        StopAllCoroutines();
        currentMana = maxMana;
        StartCoroutine(NatureMana());
    }

    private void Update()
    {
        maneSlider.value = Mathf.Lerp(maneSlider.value, currentMana / maxMana, Time.deltaTime * 10f);
    }

    public void UseMana(float useMana)
    {
        currentMana -= useMana;
    }

    private IEnumerator NatureMana()
    {
        while (true)
        {
            if (currentMana <= maxMana) currentMana += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
