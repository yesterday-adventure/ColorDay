using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BulletSwap : MonoBehaviour
{
    static Vector3 middlePos;
    static Vector3 leftPos;
    static Vector3 rightPos;
    static float bigSize = 2f;
    static float smallSize = 1f;

    [SerializeField] Image middleImg;
    [SerializeField] Image rightImg;
    [SerializeField] Image leftImg;
    private float dotweenDelay = 0f;

    public int idx = 3;
    public ColorEnum colorEnum = ColorEnum.red;
    private void Start()
    {
        middlePos = middleImg.transform.position;
        leftPos = leftImg.transform.position;
        rightPos = rightImg.transform.position;
        dotweenDelay = Fire.instance.FireDelay - 0.1f;
    }

    private void Update()
    {
        Swap();
    }

    private void Swap()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeRight();
            idx++;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeLeft();
            idx--;
            if (idx == 0)
                idx = 3;
        }

        if (idx % 3 == 0) colorEnum = ColorEnum.red;
        else if (idx % 3 == 1) colorEnum = ColorEnum.yellow;
        else colorEnum = ColorEnum.blue;
    }

    private void ChangeRight()
    {
        Image temp = middleImg;
        middleImg = rightImg;
        rightImg = leftImg; 
        leftImg = temp;
        Animation();
    }

    private void ChangeLeft()
    {
        Image temp = middleImg;
        middleImg = leftImg;
        leftImg = rightImg;
        rightImg = temp;
        Animation();
    }

    private void Animation()
    {
        middleImg.rectTransform.DOMove(middlePos, dotweenDelay);
        middleImg.rectTransform.DOScale(bigSize, dotweenDelay);
        leftImg.rectTransform.DOMove(leftPos, dotweenDelay);
        leftImg.rectTransform.DOScale(smallSize, dotweenDelay);
        rightImg.rectTransform.DOMove(rightPos, dotweenDelay);
        rightImg.rectTransform.DOScale(smallSize, dotweenDelay);
    }
}
