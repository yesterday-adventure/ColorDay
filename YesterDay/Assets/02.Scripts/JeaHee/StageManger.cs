using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class StageManger : MonoBehaviour
{
    [SerializeField]
    [Header("!�̴ϸ� �̸� �� �̸��̶� �����ϰ� �ٲܰ�!")]
    List<GameObject> sceneNames = new List<GameObject>();

    Camera _mainCam;

    int currentIndex = 0;

    private void Awake()
    {
        _mainCam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            DecreaseIndex();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            IncreaseIndex();
        }
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            LoadScene();
        }
    }

    public void LoadScene()
    {
        Debug.Log($"{currentIndex + 1}���������� �̵�!");
        //SceneManager.LoadScene(sceneNames[currentIndex].name);
    }

    [ContextMenu("Increase")]
    public void IncreaseIndex()
    {
        if (currentIndex >= sceneNames.Count - 1) return;
        currentIndex++;
        _mainCam.transform.DOMoveX(sceneNames[currentIndex].transform.position.x, 1f);
    }

    [ContextMenu("Decrease")]
    public void DecreaseIndex()
    {
        if (currentIndex == 0) return;
        currentIndex--;
        _mainCam.transform.DOMoveX(sceneNames[currentIndex].transform.position.x, 0.5f);
    }
}
