using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GamePlayButton : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;       // â�� ������ �� ���
    [SerializeField]
    private GameObject SettingWindow;       // ���� â
    [SerializeField]
    private GameObject ExitWindow;      // ������â

    [SerializeField]
    private int appearedTime = 1;   // ����� ������� �ð�

    bool possible = true;   // �ִϸ��̼��� �� �۵��ϴ� �߿��� â�� �߸� �ȵ�. â�� �� �� ���� ���� true�� �Ұž�
    bool setting = false, exit = false;     // �� â���� �����ֳ�

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))       // esc �� �����ٸ�
        {
            if (possible)       // â�� ����� �� �ִٸ�
            {
                if (exit)       // ���� exitâ�� ���� ���� �ִٸ�
                {
                    ExitWindowDisapear();   // â�� ���ְ�
                    exit = !exit;       // Ȱ��ȭ�� �ͽ�Ʈ�� ���ش�.
                }
                else
                {
                    if (!setting)   // ����â�� ���� �ִٸ�
                    {
                        SettingWindowAppear();      // ����â ���ְ�
                        setting = !setting;     // ����â�� �����ִٰ� �˸���
                    }
                    else
                    {
                        SettingWindowDisapear();        // ����â ���ְ�
                        setting = !setting;     // ����â �����ٰ� �˸���
                    }
                }
            }
        }
    }

    void SettingWindowAppear()
    {
        possible = false;   // ������ â�� ������ �־ Ű �Է��� �ȹ����ž�
        panel.SetActive(true);  // ���� �г� ������Ʈ�� ���ְ�
        SettingWindow.SetActive(true);      // ���� ����â�� ���ְ�
        panel.GetComponent<Image>().DOFade(0.4f, appearedTime);     // ��Ӱ� ������ְ�
        SettingWindow.transform.DOScale(new Vector3(1, 1, 1), appearedTime).SetEase(Ease.OutBack);      // â�� �� �ϰ� ������ ���ش�
        StartCoroutine(Wait(appearedTime, false));      // �׸��� possible�� ���ֱ� ���ؼ� �ִϰ� ���� ������ ��ٸ���
    }

    void SettingWindowDisapear()
    {
        possible = false;   // �ִϸ��̼� ������ ���ִ� �ž�
        panel.GetComponent<Image>().DOFade(0, appearedTime);    // ��ο��� ���� �������ְ�
        SettingWindow.transform.DOScale(new Vector3(0, 0, 0), appearedTime).SetEase(Ease.InBack);       // â�� �����ϰ� ������� ���ش�.
        StartCoroutine(Wait(appearedTime, true));   // possible �� ������Ʈ���� ���ֱ� ���ؼ� �ҷ�����
    }

    public void ExitWindowAppear()  // ��ư�� ������ �ͽ�Ʈâ�� ����
    {
        exit = true;    // �ͽ�Ʈ â�� ���Ծ�
        SettingWindowDisapear();    // �ͽ�Ʈ â�� ���;� �ϴϱ�
        possible = false;   // ���� â�� ������ �־�
        ExitWindow.SetActive(true);     // �ͽ�Ʈ â�� �����
        ExitWindow.transform.DOScale(new Vector3(1, 1, 1), appearedTime).SetEase(Ease.OutBack);     // �ͽ�Ʈ â�� �� �ϰ� ���Ծ�
        StartCoroutine(Wait(appearedTime, false));      // �ִϸ��̼��� �������� �˷��ֱ� ���ؼ�
    }

    void ExitWindowDisapear()
    {
        possible = false;   // ���� â�� ������� �־�
        ExitWindow.transform.DOScale(new Vector3(0, 0, 0), appearedTime).SetEase(Ease.InBack);  // º �������
        StartCoroutine(Wait(appearedTime, true));   // �� ��������� ��� ������.
    }

    IEnumerator Wait(int delay, bool disappear)
    {
        yield return new WaitForSeconds(delay + 0.1f);  // ������ + 0.1��ŭ�� ��ٷ�����.
        possible = true;    // ���� â ����� �����ϴ� ���� �˷��ְ�
        if (disappear)  // ���� â�� ������� ���̶�� ��� ������.
        {
            panel.SetActive(false);
            SettingWindow.SetActive(false);
            if (!exit)  // ���࿡ �ͽ�Ʈ�� �ƴ� ��쿡�� ������� 
            {
                ExitWindow.SetActive(false);
            }
        }
    }
}
