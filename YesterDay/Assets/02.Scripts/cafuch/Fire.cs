using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//풀 매니저 사용하기

public class Fire : MonoBehaviour
{
    public static Fire instance;
    BulletSwap bulletSwap;

    // [SerializeField] private List<Material> bulletColors = new List<Material>();
    [SerializeField] private float fireDelay, chngeDelay;
    [SerializeField] private GameObject firePos;
    [SerializeField] private GameObject curBullet;
    private bool canFire = true;

    public float FireDelay { get => fireDelay;}
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("Fire is Multiplying");
        bulletSwap = GetComponent<BulletSwap>();
        //curBullet.GetComponent<MeshRenderer>().materials[0];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canFire) //메테리얼을 바꿔주자?
        {
            Debug.Log("thghksehla");
            GameObject obj = Instantiate(curBullet, firePos.transform.position, transform.rotation);
            obj.GetComponent<ColorBullet>().BulletColor = bulletSwap.colorEnum;
            // GameObject obj = PoolManager.Instance.Pop(curBullet, firePos.transform.position, Quaternion.identity);
            MeshRenderer mesh = obj.GetComponent<MeshRenderer>();

            switch (bulletSwap.colorEnum)
            {

                case ColorEnum.red:
                    {
                        mesh.material = ColorManager.instance.colorMaterials[1];
                    }
                    break;
                case ColorEnum.yellow:
                    {
                        mesh.material = ColorManager.instance.colorMaterials[10];
                    }
                    break;
                case ColorEnum.blue:
                    {
                        mesh.material = ColorManager.instance.colorMaterials[6];
                    }
                    break;
            }

            canFire = false;
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(fireDelay);
        canFire = true;
    }
}
