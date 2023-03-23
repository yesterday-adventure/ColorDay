using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    BulletSwap bulletSwap;

    //[SerializeField] private GameObject redBullet, greenBullet, blueBullet;
    [SerializeField] private List<GameObject> bullets;
    [SerializeField] private float fireDelay, chngeDelay;
    [SerializeField] private GameObject firePos, curBullet;
    private bool canFire = true;
    int num = 0;

    void Awake()
    {
        bulletSwap = GetComponent<BulletSwap>();
        curBullet = bullets[num]; //�ʱ� ���� �������� ����
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("������");
            BulletFire();

            curBullet = bullets[(int)bulletSwap._BulletType];
            
            //curBullet = bulletSwap._BulletType;
        }
    }

    private void BulletFire()
    {
        Instantiate(curBullet, firePos.transform.position, Quaternion.identity);
        canFire = false;
        StartCoroutine("BulletFire");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(fireDelay);
        canFire = true;
    }
}
