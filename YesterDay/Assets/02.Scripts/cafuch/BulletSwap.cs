using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    Red = 0,
    Green,
    Blue
};

public class BulletSwap : MonoBehaviour
{
    [SerializeField] BulletType curBulletType = BulletType.Red;

    public BulletType _BulletType { get { return curBulletType; } set { curBulletType = value; } }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) Swap(true);
        else if (Input.GetKeyDown(KeyCode.Q)) Swap(false);
    }

    private void Swap(bool chgeNext)
    {
        if (chgeNext)
        {
            if (curBulletType == BulletType.Blue) curBulletType = BulletType.Red;
            curBulletType = (BulletType)curBulletType + 1;
        }
        else
        {
            if (curBulletType == BulletType.Red) curBulletType = BulletType.Blue;
            curBulletType = (BulletType)curBulletType - 1;
        }
    }
}
