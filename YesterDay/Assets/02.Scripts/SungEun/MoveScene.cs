using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public void GoScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void DebugShow(string show)
    {
        Debug.Log(show);
    }
}
