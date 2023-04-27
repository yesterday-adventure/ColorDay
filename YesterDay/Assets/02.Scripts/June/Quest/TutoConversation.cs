using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutoConversation : MonoBehaviour
{
    public static TutoConversation Instance;

    [SerializeField] TextMeshProUGUI slimeTxt;
    public int idx = 0;

    public string[] conversationList;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("TutoConversation is Multiple");
    }
}
