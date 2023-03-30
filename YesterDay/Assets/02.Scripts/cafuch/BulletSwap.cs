using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSwap : MonoBehaviour
{
    public int idx = 3;
    public ColorEnum colorEnum = ColorEnum.red;
    private void Update() {
        
        Swap();    
    }

    private void Swap()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            idx++;
        }
        else if (Input.GetKeyDown(KeyCode.Q)) 
        {
            idx--;
            if(idx == 0)
                idx = 3;
        }

        if (idx % 3 == 0) colorEnum = ColorEnum.red;
        else if (idx % 3 == 1) colorEnum = ColorEnum.yellow;
        else colorEnum = ColorEnum.blue;
    }
}
