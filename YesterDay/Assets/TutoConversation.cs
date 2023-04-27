using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoConversation : MonoBehaviour
{
    public static TutoConversation Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("TutoConversation is Multiple");
    }
}
