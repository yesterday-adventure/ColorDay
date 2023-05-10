using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TutoConversation : MonoBehaviour
{
    public static TutoConversation Instance;

    [SerializeField] TextMeshProUGUI slimeTxt;
    [SerializeField] Image image;
    [SerializeField] Sprite slime;
    [SerializeField] Sprite user;
    public int idx = 0;

    Text text;
    public string[] conversationList;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("TutoConversation is Multiple");
    }

    private void Start()
    {
        Text();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            idx++;
            if(idx < conversationList.Length)
                Text();
            else
            {
                WhiteMap.instance.White();
                gameObject.SetActive(false);
            }
        }
    }

    public void Text()
    {
        if(idx % 2 == 0) 
            image.sprite = slime;
        if (idx % 2 == 1)
            image.sprite = user;
        slimeTxt.text = conversationList[idx];
    }
}
