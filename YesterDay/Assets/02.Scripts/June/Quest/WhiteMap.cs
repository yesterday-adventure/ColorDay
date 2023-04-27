using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteMap : MonoBehaviour
{
    public void White()
    {
        MeshRenderer[] allChildren = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer child in allChildren)
        {
            Material[] mat = child.materials;
            foreach (var item in mat)
            {
                item.color = Color.white;
            }
        }
    }
}
