using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageTuto : MonoBehaviour
{
    public static StageTuto Instance;

    [SerializeField] TextMeshProUGUI showTmp;
    [SerializeField] TextMeshProUGUI topTmp;
    [SerializeField] public TextMeshProUGUI processTmp;
    [SerializeField] GameObject endPanel;

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
        TopText();
        processTmp.text = "";
    }

    public void ClearQuest()
    {
        processTmp.text = "";
        ++idx;
        if (idx > 4)
        {
            StartCoroutine(End());
        }
        else
        {
            ShowText();
            TopText();
        }
    }
    public void ShowText() => showTmp.text = Txt[idx];
    public void TopText() => topTmp.text = $"< {idx + 1} / 5 >";

    IEnumerator End()
    {
        endPanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("StageSelect");
    }
}
