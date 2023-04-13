using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObject : MonoBehaviour
{
    public static TutorialObject instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("TutorialObject is Multiple");
    }

    public void Resurrection(GameObject obj)
    {
        StartCoroutine(ResurrectionCo(obj));
    }

    IEnumerator ResurrectionCo(GameObject obj)
    {
        Debug.Log("ÁÖ±Ý");
        yield return new WaitForSeconds(2f);
        Debug.Log("¶Ñ·ç·ç·ç¶ò±î»×±î »ì¾Æ³ª¶ó¾å!");
        obj.SetActive(true);
    }
}
