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
                    exit = !exit;       // Ȱ��ȭ�� �ͽ�Ʈ�� ���ش�.
                    ExitWindowDisapear();   // â�� ���ְ�
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

     public void SettingWindowAppear()
    {
        possible = false;   // ������ â�� ������ �־ Ű �Է��� �ȹ����ž�
        panel.SetActive(true);  // ���� �г� ������Ʈ�� ���ְ�
        SettingWindow.SetActive(true);      // ���� ����â�� ���ְ�
        panel.GetComponent<Image>().DOFade(0.4f, appearedTime);     // �г��� �̿��ؼ� ��Ӱ� ������ְ�
        SettingWindow.transform.DOScale(new Vector3(1, 1, 1), appearedTime).SetEase(Ease.OutBack);      // â�� �� �ϰ� ������ ���ش�
        StartCoroutine(Wait(appearedTime, false));      // �׸��� possible�� ���ֱ� ���ؼ� �ִϰ� ���� ������ ��ٸ���
    }

    public void SettingWindowDisapear(bool in_exit = false)
    {
        possible = false;   // �ִϸ��̼� ������ ���ִ� �ž�
        SettingWindow.transform.DOScale(new Vector3(0, 0, 0), appearedTime).SetEase(Ease.InBack);       // â�� �����ϰ� ������� ���ش�.
        if (!in_exit)
        {
        panel.GetComponent<Image>().DOFade(0, appearedTime);    // ��ο��� ���� ������� �ϰ�
        }
        StartCoroutine(Wait(appearedTime, true));   // possible �� ������Ʈ���� ���ֱ� ���ؼ� �ҷ�����
    }

    public void ExitWindowAppear()  // ��ư�� ������ �ͽ�Ʈâ�� ����
    {
        exit = true;    // �ͽ�Ʈ â�� ���Ծ�
        SettingWindowDisapear(true);    // �ͽ�Ʈ â�� ���;� �ϴϱ�
        possible = false;   // ���� â�� ������ �־�
        ExitWindow.SetActive(true);     // �ͽ�Ʈ â�� �����
        ExitWindow.transform.DOScale(new Vector3(1, 1, 1), appearedTime).SetEase(Ease.OutBack);     // �ͽ�Ʈ â�� �� �ϰ� ���Ծ�
        StartCoroutine(Wait(appearedTime, false));      // �ִϸ��̼��� �������� �˷��ֱ� ���ؼ�
    }

    public void ExitWindowDisapear()
    {
        Debug.Log("�ͽ�Ʈ â ���� ����");
        possible = false;   // ���� �ͽ�Ʈ�� ������� �־�
        panel.GetComponent<Image>().DOFade(0, appearedTime);    // ��ο��� ���� ������� �ϰ�
        ExitWindow.transform.DOScale(new Vector3(0, 0, 0), appearedTime).SetEase(Ease.InBack);  // º �������
        StartCoroutine(Wait(appearedTime, true));   // �� ��������� ��� ������.
    }

    public void RealExit()
    {
        panel.GetComponent<Image>().DOFade(1, appearedTime);    // ������ ��ο�������
        StartCoroutine(Wait(appearedTime, false, true));   // ��ο�� Ȯ���ϰ� ����.
    }

    IEnumerator Wait(int delay, bool disappear, bool in_exit = false)
    {
        yield return new WaitForSeconds(delay + 0.1f);  // ������ + 0.1��ŭ�� ��ٷ�����.

        if (in_exit)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        possible = true;    // ���� â ����� �����ϴ� ���� �˷��ְ�
        if (disappear)  // ���� â�� ������� ���̶�� ��� ������.
        {
            SettingWindow.SetActive(false);
            if (!exit)  // ���࿡ �ͽ�Ʈ�� �ƴ� ��쿡�� ������� 
            {
                panel.SetActive(false);
                ExitWindow.SetActive(false);
            }
        }
    }
}
