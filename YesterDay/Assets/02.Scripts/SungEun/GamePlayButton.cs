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
    private GameObject SettingWindow, GoSettingButton, GoExitButton;       // ���� â, ���� ���� ��ư
    [SerializeField]
    private GameObject ExitWindow;      // ������â
    [SerializeField]
    private List<Button> ActiveButton = new List<Button>();

    [SerializeField]
    private int appearedTime = 1;   // ����� ������� �ð�

    bool possible = true;   // �ִϸ��̼��� �� �۵��ϴ� �߿��� â�� �߸� �ȵ�. â�� �� �� ���� ���� true�� �Ұž�
    bool setting = false, exit = false;     // �� â���� �����ֳ�

    [SerializeField]
    private AudioSource ButtonShow;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))       // esc �� �����ٸ�
        {
            if (possible)       // â�� ����� �� �ִٸ�
            {
                // �Ҹ� ���
                ButtonShow.Play();
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
        Debug.Log("����â ����");

        GoSettingButton.SetActive(false);
        GoExitButton.SetActive(false);
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
        if (!in_exit)   // ���� �ͽ�Ʈ�� ������ ����â�� ������ �����
        {
            GoSettingButton.SetActive(true);
            GoExitButton.SetActive(true);
            panel.GetComponent<Image>().DOFade(0, appearedTime);    // ��ο��� ���� ������� �ϰ�
        }
        StartCoroutine(Wait(appearedTime, true));   // possible �� ������Ʈ���� ���ֱ� ���ؼ� �ҷ�����



        // ���⼭ ������ ����? �ϸ� �� ��, ok �ϱ�
    }

    public void ExitWindowAppear(bool isNew = false)  // ��ư�� ������ �ͽ�Ʈâ�� ����
    {
        exit = true;    // �ͽ�Ʈ â�� ���Ծ�
        SettingWindowDisapear(true);    // �ͽ�Ʈ â�� ���;� �ϴϱ�
        possible = false;   // ���� â�� ������ �־�
        if (isNew)      // �̰� ����â���� ���� �ƴ϶� ��¥ exit �� �����Ŷ��
        {
            panel.SetActive(true);
            panel.GetComponent<Image>().DOFade(0.4f, appearedTime);     // �г��� ���ش�.
        }
        ExitWindow.SetActive(true);     // �ͽ�Ʈ â�� �����
        ExitWindow.transform.DOScale(new Vector3(1, 1, 1), appearedTime).SetEase(Ease.OutBack);     // �ͽ�Ʈ â�� �� �ϰ� ���Ծ�
        StartCoroutine(Wait(appearedTime, false));      // �ִϸ��̼��� �������� �˷��ֱ� ���ؼ�
    }

    public void ExitWindowDisapear()
    {
        exit = false;    // �ͽ�Ʈ â�� �׾���
        GoSettingButton.SetActive(true);
        GoExitButton.SetActive(true);
        possible = false;   // ���� �ͽ�Ʈ�� ������� �־�
        panel.GetComponent<Image>().DOFade(0, appearedTime);    // ��ο��� ���� ������� �ϰ�
        ExitWindow.transform.DOScale(new Vector3(0, 0, 0), appearedTime).SetEase(Ease.InBack);  // º �������
        StartCoroutine(Wait(appearedTime, true));   // �� ��������� ��� ������.
    }

    public void RealExit()
    {
        // �̰� ȭ�� ��� �ڿ� �־ �̰� �ٲٸ� ���� ��
        panel.transform.SetAsLastSibling();     // ���̾��Ű â���� ���� �Ʒ��� ������ ���� ���� �׷������� �Ѵ�
        panel.GetComponent<Image>().DOFade(1, appearedTime + appearedTime);    // ������ ��ο�������
        StartCoroutine(Wait(appearedTime, false, true));   // ��ο�� Ȯ���ϰ� ����.
    }

    IEnumerator Wait(int delay, bool disappear, bool in_exit = false)
    {
        foreach(Button b in ActiveButton)   // ��ư�� ������ �ʰ�
        {
            b.interactable = false;
        }

        yield return new WaitForSeconds(delay + 0.1f);  // ������ + 0.1��ŭ�� ��ٷ�����.

        foreach (Button b in ActiveButton)  // ��ư �ٽ� ������
        {
            b.interactable = true;
        }

        if (in_exit)
        {
            yield return new WaitForSeconds(delay);     // �Ϲݲ��� 2�� ���� �� ���� �׷��ֱ�
#if UNITY_EDITOR        // ���� ����Ƽ���� ���������(����Ȱ� �ƴϸ�)
            UnityEditor.EditorApplication.isPlaying = false;        // ����Ƽ ���������� �÷��̸� �����ֱ�
#else
            Application.Quit();     // �� ������
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
