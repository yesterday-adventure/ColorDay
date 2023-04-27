using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoIntro : MonoBehaviour
{
    public static TutoIntro instance;

    [Header("오브젝트")]
    [SerializeField] PlayerMove playerMove;
    [SerializeField] Fire fire;
    [SerializeField] BulletSwap bulletSwap;
    [SerializeField] GameObject canvas;
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
    }

    public void TutoStart()
    {
        canvas.SetActive(true);
        PlayerCamera.SetActive(true);
        SlimeCamera.SetActive(false);
        PlayerCamera.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = 0;
        PlayerCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 0;
    }
}
