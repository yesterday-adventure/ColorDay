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
        curBullet = redBullet; //초기 색은 빨강으로 시작
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            Debug.Log("눌럿음");
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
