using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : ColorEnemy
{
    int[] arr = { 1, 6, 10, 7, 11, 16, 12, 21, 22, 26, 8, 13 };
    int[] arrEasy = { 1, 6, 10};
    int[] arrNormal = {7, 11, 16};
    int[] arrHard = { 16, 12, 21, 22, 26, 8, 13 };

    protected override void OnEnable()
    {
        currentColor = ColorEnum.white;
        dieColor = (ColorEnum)arr[Random.Range(0, arr.Length)];
        if (StageTuto.Instance.idx == 1)
            SetColorEasy();
        else if (StageTuto.Instance.idx == 2 || StageTuto.Instance.idx == 3)
            SetColorNormal();
        else if (StageTuto.Instance.idx == 4)
            SetColorHard();

        if(StageTuto.Instance.idx == 3)
            SetCurColorNormal();

        base.OnEnable();
    }

    private void FixedUpdate()
    {
        if(StageTuto.Instance.idx == 1 && currentColor != ColorEnum.white && currentColor != dieColor)
        {
            gameObject.SetActive(false);
            if(TutoSecondQuest.Instance != null)
                TutoSecondQuest.Instance.cnt--;
        }
        else if(StageTuto.Instance.idx == 2 && (currentColor == ColorEnum.purple || currentColor == ColorEnum.orange ||
            currentColor == ColorEnum.green) && currentColor != dieColor)
        {
            gameObject.SetActive(false);
            if(TutoThirdQuest.Instance != null)
                TutoThirdQuest.Instance.cnt--;
        }
    }

    private void OnDisable()
    {
        if (gameObject.activeSelf == false && TutorialObject.instance != null)
        {
            TutorialObject.instance.Resurrection(this.gameObject);
            if(TutoSecondQuest.Instance != null && StageTuto.Instance.idx == 1)
                TutoSecondQuest.Instance.cnt++;
            else if (TutoThirdQuest.Instance != null && StageTuto.Instance.idx == 2)
                TutoThirdQuest.Instance.cnt++;
            else if (TutoFourthQuest.Instance != null && StageTuto.Instance.idx == 3)
                TutoFourthQuest.Instance.cnt++;
            else if(TutoFivethQuest.Instance != null && StageTuto.Instance.idx == 4)
                TutoFivethQuest.Instance.cnt++;
        }
    }

    public void SetColorEasy() => dieColor = (ColorEnum)arrEasy[Random.Range(0, arrEasy.Length)];

    public void SetColorNormal() => dieColor = (ColorEnum)arrNormal[Random.Range (0, arrNormal.Length)];

    public void SetColorHard() => dieColor = (ColorEnum)arrHard[Random.Range(0, arrHard.Length)];

    public void SetCurColorNormal()
    {
        int idx = Random.Range(0, arrNormal.Length);
        while ((ColorEnum)arrNormal[idx] == dieColor)
        {
            idx = Random.Range(0, arrNormal.Length);
        }
        currentColor = (ColorEnum)arrNormal[idx];
    }
}