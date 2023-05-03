using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoIntro : MonoBehaviour
{
    public static TutoIntro instance;

    [Header("오브젝트")]
    [SerializeField] TPlayerMove playerMove;
    [SerializeField] Fire fire;
    [SerializeField] BulletSwap bulletSwap;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject converSationCanvas;
    [SerializeField] GameObject[] Quest;

    [Header("카메라")]
    [SerializeField] GameObject PlayerCamera;
    [SerializeField] GameObject SlimeCamera;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("TutoIntro is Multiple");
    }
    void Start()
    {
        playerMove.enabled = false;
        fire.enabled = false;
        bulletSwap.enabled = false;
        foreach (GameObject q in Quest)
        {
            q.SetActive(false);
        }
        canvas.SetActive(false);
        PlayerCamera.SetActive(false);
        SlimeCamera.SetActive(true);
        converSationCanvas.SetActive(false);
    }

    public void TutoStart()
    {
        canvas.SetActive(true);
        PlayerCamera.SetActive(true);
        SlimeCamera.SetActive(false);
        PlayerCamera.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = 0;
        PlayerCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 0;
        StartCoroutine(Delay());
    }

    public void GameStart()
    {
        playerMove.enabled = true;
        fire.enabled = true;
        bulletSwap.enabled = true;
        foreach (GameObject q in Quest)
        {
            q.SetActive(true);
        }
        PlayerCamera.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = 300;
        PlayerCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 300;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        converSationCanvas.SetActive(true) ;
    }
}
