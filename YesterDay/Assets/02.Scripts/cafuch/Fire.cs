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

    void Awake()
    {
        bulletSwap = GetComponent<BulletSwap>();
        curBullet = bullets[0]; //초기 색은 빨강으로 시작
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            Debug.Log("눌럿음");
            //BulletFire();
            //StartCoroutine("BulletFire");
            curBullet = bulletSwap._BulletType;
            Instantiate(curBullet, firePos.transform.position, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            
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
