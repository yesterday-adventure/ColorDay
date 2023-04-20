using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class StageManger : MonoBehaviour
{
    [SerializeField]
    [Header("!미니맵 이름 씬 이름이랑 동일하게 바꿔야 함!")]
    List<GameObject> sceneNames = new List<GameObject>();

    Camera _mainCam;

    int currentIndex = 0;
    bool canMove = true;

    private void Awake()
    {
        _mainCam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadScene();
        }
        if (canMove)
        {
            if (Input.GetKey(KeyCode.A))
            {
                DecreaseIndex();
            }
            if (Input.GetKey(KeyCode.D))
            {
                IncreaseIndex();
            }
        }
    }

    public void LoadScene()
    {
        Debug.Log($"{currentIndex + 1}스테이지로 이동!");
        //SceneManager.LoadScene(sceneNames[currentIndex].name);
    }

    [ContextMenu("Increase")]
    public void IncreaseIndex()
    {
        if (currentIndex >= sceneNames.Count - 1) return;
        canMove = false;
        currentIndex++;
        _mainCam.transform.DOMoveX(sceneNames[currentIndex].transform.position.x, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            canMove = true;
        });
    }

    [ContextMenu("Decrease")]
    public void DecreaseIndex()
    {
        if (currentIndex == 0) return;
        canMove = false;
        currentIndex--;
        _mainCam.transform.DOMoveX(sceneNames[currentIndex].transform.position.x, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            canMove = true;
        });
    }
}
