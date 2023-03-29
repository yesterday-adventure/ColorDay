using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSwap : MonoBehaviour
{
    //red = 1 2
    //blue = 6 0 
    //yellow = 10 1

    public int idx = 9;
    public ColorEnum colorEnum = ColorEnum.red;
    private void Update() {
        
        Swap();    
    }

    private void Swap()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            idx++;
            if(idx == 0)
                idx = 9;
        }
        else if (Input.GetKeyDown(KeyCode.E)) 
        {
            idx--;
        }

        if (idx % 3 == 0) colorEnum = ColorEnum.red;
        else if (idx % 3 == 1) colorEnum = ColorEnum.yellow;
        else colorEnum = ColorEnum.blue;
    }

    //0 예외처리
}
