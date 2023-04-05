using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    static public ColorManager instance;
    public List<Material> colorMaterials;
    public List<Material> GhostcolorMaterials;

    //public Dictionary<int, Material> colorMaterialsDC;
    //public Dictionary<int, Material> ghostcolorMaterialsDC;

    private void Awake()
    {
        if (instance != null)
            Debug.LogError($"{transform}: ColorManager Multiple");
        else
            instance = this;
    }

    public ColorEnum AddColor(ColorEnum originColor, ColorEnum addColor)
    {
        Debug.Log("��Ҵ�!");
        if (CanChangeColor(originColor, addColor))
        {
            return originColor + (int)addColor;
        }
        else
            return originColor;
    }


    public bool CanChangeColor(ColorEnum originColor, ColorEnum addColor)
    {
        if (originColor == addColor || (originColor == ColorEnum.puple) && (addColor == ColorEnum.yellow)
            || (originColor == ColorEnum.orange) && (addColor == ColorEnum.blue) || (originColor == ColorEnum.green) && (addColor == ColorEnum.red))
            return false;

        return true;
    }

    public bool CheckColor(ColorEnum originColor, ColorEnum compareColor)
    {
        if (originColor == compareColor)
            return true;
        else
            return false;
    }
    public ColorEnum ChangeWhite() => ColorEnum.white;
}