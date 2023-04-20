using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageTuto : MonoBehaviour
{
    public static StageTuto Instance;

    [SerializeField] TextMeshProUGUI showTmp;
    [SerializeField] TextMeshProUGUI TopTmp;

    [SerializeField] string[] Txt;
    public int idx = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("StageTuto is Multiple");
    }
    private void Start()
    {
        ShowText();
    }

    public void ClearQuest()
    {
        ++idx;
        ShowText();
        TopText();
    }
    public void ShowText() => showTmp.text = Txt[idx];
    public void TopText() => TopTmp.text = $"< {idx + 1} / 5 >";
}
