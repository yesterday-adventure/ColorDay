using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerQuest : MonoBehaviour
{
    [SerializeField] GameObject questPanel;
    private bool isShow = true;
    Vector3 showPos;
    Vector3 hiddenPos;

    private void Awake()
    {
        showPos = questPanel.transform.position;
        hiddenPos = new Vector3(showPos.x + 700, showPos.y, showPos.z);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(isShow )
            {
                isShow = false;
                questPanel.transform.DOMove(hiddenPos, 1f);
            }
            else
            {
                isShow = true;
                questPanel.transform.DOMove(showPos, 1f);
            }
        }
    }
}
