using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject redBullet, greenBullet, blueBullet;
    [SerializeField] private float fireDelay, chngeDelay;
    [SerializeField] private GameObject firePos, curBullet;
    private string type;
    private bool canFire = true;

    void Awake()
    {
        curBullet = redBullet; //�ʱ� ���� �������� ����
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            Debug.Log("������");
            BulletFire();
            StartCoroutine("BulletFire");
        }
    }

    private void BulletFire()
    {
        Instantiate(curBullet, firePos.transform.position, Quaternion.identity);
        canFire = false;
    }

    IEnumerator Delay()
    {
        //if (type == this.type)
        //{


        //}

        yield return new WaitForSeconds(fireDelay);
        canFire = true;
    }
}
