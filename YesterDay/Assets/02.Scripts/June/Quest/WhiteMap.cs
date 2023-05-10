using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteMap : MonoBehaviour
{
    public static WhiteMap instance;
    [SerializeField] CinemachineFreeLook cm;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Debug.LogError("Whitemap is multiple");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        StartCoroutine(WhiteCo());
    }


    public void White()
    {
        StartCoroutine(ShakeCam());
    }

    IEnumerator ShakeCam()
    {
        Vector3 startRotation = cm.transform.eulerAngles;

        float power = 10f;
        float shakeTime = 3f;
        float shakeIntensity = 0.1f;
        StartCoroutine(WhiteCo());
        while (shakeTime > 0)
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            float z = Random.Range(-1f, 1f);
            transform.rotation = Quaternion.Euler(startRotation + new Vector3(x, y, z) * shakeIntensity * power);

            shakeTime -= Time.deltaTime;

            yield return null;
        }

        transform.rotation = Quaternion.Euler(startRotation);
    }

    IEnumerator WhiteCo()
    {
        MeshRenderer[] allChildren = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer child in allChildren)
        {
            Material[] mat = child.materials;
            foreach (var item in mat)
            {
                item.color = Color.white;
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
