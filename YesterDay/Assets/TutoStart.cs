using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoStart : MonoBehaviour
{
    bool gameStart = false;
    [SerializeField] GameObject[] off;
    [SerializeField] GameObject camera1;
    [SerializeField] GameObject camera3;
    [SerializeField] GameObject camera4;

    float time = 0f;
    private void Awake()
    {
        foreach (GameObject obj in off)
        {
            obj.SetActive(false);
        }
        camera1.SetActive(true);
        camera3.SetActive(false);
        camera4.SetActive(false);
    }
    private void Update()
    {
        if (gameStart)
        {
            foreach (GameObject obj in off)
            {
                obj.SetActive(true);
            }
        }
        time += Time.deltaTime;


        if (camera1.activeSelf)
        {
                camera1.transform.position = new Vector3(camera1.transform.position.x, camera1.transform.position.y,
                    camera1.transform.position.z + 0.3f);
            if (time > 4f)
            {
                camera1.SetActive(false);
                camera3.SetActive(true);
                time = 0;
            }
        }
        else if (camera3.activeSelf)
        {
            camera3.transform.position = new Vector3(camera3.transform.position.x, camera3.transform.position.y,
                    camera3.transform.position.z + 0.3f);
            if (time > 4f)
            {
                camera3.SetActive(false);
                camera4.SetActive(true);
                gameStart = true;
                time = 0;
            }
        }

    }
}
