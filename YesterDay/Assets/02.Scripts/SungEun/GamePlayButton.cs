using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GamePlayButton : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;       // 창의 검은색 뒷 배경
    [SerializeField]
    private GameObject SettingWindow, GoSettingButton, GoExitButton;       // 셋팅 창, 셋팅 열기 버튼
    [SerializeField]
    private GameObject ExitWindow;      // 나가기창
    [SerializeField]
    private List<Button> ActiveButton = new List<Button>();

    [SerializeField]
    private int appearedTime = 1;   // 생기고 사라지는 시간

    bool possible = true;   // 애니메이션이 다 작동하는 중에는 창이 뜨면 안돼. 창이 뜰 수 있을 때만 true로 할거야
    bool setting = false, exit = false;     // 각 창들이 켜져있냐

    [SerializeField]
    private AudioSource ButtonShow;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))       // esc 를 눌렀다면
        {
            if (possible)       // 창을 사용할 수 있다면
            {
                // 소리 재생
                ButtonShow.Play();
                if (exit)       // 만약 exit창이 현재 켜져 있다면
                {
                    exit = !exit;       // 활성화된 익시트를 꺼준다.
                    ExitWindowDisapear();   // 창을 꺼주고
                }
                else
                {
                    if (!setting)   // 셋팅창이 현재 있다면
                    {
                        SettingWindowAppear();      // 셋팅창 켜주고
                        setting = !setting;     // 셋팅창이 켜져있다고 알리기
                    }
                    else
                    {
                        SettingWindowDisapear();        // 셋팅창 꺼주고
                        setting = !setting;     // 셋팅창 꺼졌다고 알리기
                    }
                }
            }
        }
    }

     public void SettingWindowAppear()
    {
        Debug.Log("셋팅창 누름");

        GoSettingButton.SetActive(false);
        GoExitButton.SetActive(false);
        possible = false;   // 지금은 창이 나오고 있어서 키 입력을 안받을거야
        panel.SetActive(true);  // 꺼진 패널 오브젝트를 켜주고
        SettingWindow.SetActive(true);      // 꺼진 셋팅창을 켜주고
        panel.GetComponent<Image>().DOFade(0.4f, appearedTime);     // 패널을 이용해서 어둡게 만들어주고
        SettingWindow.transform.DOScale(new Vector3(1, 1, 1), appearedTime).SetEase(Ease.OutBack);      // 창이 뿅 하고 나오게 해준다
        StartCoroutine(Wait(appearedTime, false));      // 그리고 possible를 켜주기 위해서 애니가 끝날 때까지 기다리기
    }

    public void SettingWindowDisapear(bool in_exit = false)
    {
        possible = false;   // 애니매이션 때문에 꺼주는 거야
        SettingWindow.transform.DOScale(new Vector3(0, 0, 0), appearedTime).SetEase(Ease.InBack);       // 창을 뚀잉하게 사라지게 해준다.
        if (!in_exit)   // 만약 익시트를 눌러서 셋팅창이 꺼지는 경우라면
        {
            GoSettingButton.SetActive(true);
            GoExitButton.SetActive(true);
            panel.GetComponent<Image>().DOFade(0, appearedTime);    // 어두웠던 것을 사라지게 하고
        }
        StartCoroutine(Wait(appearedTime, true));   // possible 과 오브젝트들을 꺼주기 위해서 불러주자



        // 여기서 데이터 저장? 하면 될 듯, ok 니까
    }

    public void ExitWindowAppear(bool isNew = false)  // 버튼을 누르면 익시트창이 나옴
    {
        exit = true;    // 익시트 창이 나왔어
        SettingWindowDisapear(true);    // 익시트 창이 나와야 하니까
        possible = false;   // 지금 창이 나오고 있어
        if (isNew)      // 이게 셋팅창에서 들어간게 아니라 진짜 exit 를 누른거라면
        {
            panel.SetActive(true);
            panel.GetComponent<Image>().DOFade(0.4f, appearedTime);     // 패널을 켜준다.
        }
        ExitWindow.SetActive(true);     // 익시트 창을 켜줬어
        ExitWindow.transform.DOScale(new Vector3(1, 1, 1), appearedTime).SetEase(Ease.OutBack);     // 익시트 창이 뿅 하고 나왔어
        StartCoroutine(Wait(appearedTime, false));      // 애니메이션이 끝났음을 알려주기 위해서
    }

    public void ExitWindowDisapear()
    {
        exit = false;    // 익시트 창이 죽었어
        GoSettingButton.SetActive(true);
        GoExitButton.SetActive(true);
        possible = false;   // 지금 익시트이 사라지고 있어
        panel.GetComponent<Image>().DOFade(0, appearedTime);    // 어두웠던 것을 사라지게 하고
        ExitWindow.transform.DOScale(new Vector3(0, 0, 0), appearedTime).SetEase(Ease.InBack);  // 쨘 사라졌네
        StartCoroutine(Wait(appearedTime, true));   // 다 사용했으니 모두 꺼주자.
    }

    public void RealExit()
    {
        // 이거 화면 계속 뒤에 있어서 이거 바꾸면 좋을 듯
        panel.transform.SetAsLastSibling();     // 하이어라키 창에서 가장 아래로 움직여 가장 위에 그려지도록 한다
        panel.GetComponent<Image>().DOFade(1, appearedTime + appearedTime);    // 완전히 어두워졌으면
        StartCoroutine(Wait(appearedTime, false, true));   // 어두운거 확인하고 자자.
    }

    IEnumerator Wait(int delay, bool disappear, bool in_exit = false)
    {
        foreach(Button b in ActiveButton)   // 버튼이 눌리지 않게
        {
            b.interactable = false;
        }

        yield return new WaitForSeconds(delay + 0.1f);  // 딜레이 + 0.1만큼을 기다려주자.

        foreach (Button b in ActiveButton)  // 버튼 다시 눌리게
        {
            b.interactable = true;
        }

        if (in_exit)
        {
            yield return new WaitForSeconds(delay);     // 일반꺼의 2배 정도 더 오래 그려주기
#if UNITY_EDITOR        // 만약 유니티엔진 내에서라면(빌드된거 아니면)
            UnityEditor.EditorApplication.isPlaying = false;        // 유니티 엔진내에서 플레이를 멈춰주기
#else
            Application.Quit();     // 앱 나가기
#endif
        }

        possible = true;    // 이제 창 사용이 가능하단 것을 알려주고
        if (disappear)  // 만약 창이 사라지는 것이라면 모두 꺼주자.
        {
            SettingWindow.SetActive(false);
            if (!exit)  // 만약에 익시트가 아닐 경우에만 사라지게 
            {
                panel.SetActive(false);
                ExitWindow.SetActive(false);
            }
        }
    }
}
