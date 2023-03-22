using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Data
{
    // 저장 이름
    public int level = 1;
}

public class DataManager : MonoBehaviour
{
    Data saveData = new Data();
    string savePath;

    private void Awake()
    {
        savePath = Application.dataPath + "/999.SaveData";
        if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);
    }

    public void Save()
    {
        string data = JsonUtility.ToJson(saveData);
        File.WriteAllText(savePath + "/SaveFile", data);
    }

    public void Load()
    {
        string date = File.ReadAllText(savePath + "/SaveFile");
        saveData = JsonUtility.FromJson<Data>(date);
    }
}
