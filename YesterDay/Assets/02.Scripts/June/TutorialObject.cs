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
        Debug.Log("�ֱ�");
        yield return new WaitForSeconds(2f);
        Debug.Log("�ѷ�����ױ� ��Ƴ����!");
        obj.SetActive(true);
    }
}
