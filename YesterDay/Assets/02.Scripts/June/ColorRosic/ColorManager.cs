using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro.EditorUtilities;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    
    private static ColorManager Instance;

    public static ColorManager instance
    { 
        get 
        { 
            if (Instance == null)
                Instance = FindObjectOfType<ColorManager>();
            return Instance; 
        } 
    }
    public List<Material> colorMaterials;
    public List<Material> GhostcolorMaterials;
    
    public ColorEnum AddColor(ColorEnum originColor, ColorEnum addColor)
    {
        if (CanChangeColor(originColor, addColor))
        {
            return originColor + (int)addColor;
        }
        else
            return originColor;
    }


    public bool CanChangeColor(ColorEnum originColor, ColorEnum addColor)
    {
        if (originColor == addColor ||
            ((originColor == ColorEnum.puple) && (addColor == ColorEnum.yellow)) ||
            ((originColor == ColorEnum.orange) && (addColor == ColorEnum.blue)) ||
            ((originColor == ColorEnum.green) && (addColor == ColorEnum.red)) ||
            (originColor == ColorEnum.crimson) || (originColor == ColorEnum.tangerine) || (originColor == ColorEnum.turquoise) ||
            (originColor == ColorEnum.lightgreen) || (originColor == ColorEnum.thickpuple) || (originColor == ColorEnum.violet))
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