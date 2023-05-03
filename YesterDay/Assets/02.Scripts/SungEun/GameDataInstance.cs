using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataInstance : MonoBehaviour
{
    // 싱글턴으로 만들어서 게임 내 실행 시에만 데이터 저장하도록
    // 일단 첫번째로 사운드

    #region awake 사용한 싱글턴
    static private GameDataInstance instance;
    static public GameDataInstance Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    private void Awake()
    {
        // 만약 지금 씬에서 인스턴스가 없다면
        if (instance == null)
        {
            instance = this;
            // 이걸로 해준다.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // 있으면 지워준다.
            Destroy(this.gameObject);
        }
    }
    #endregion

    // 저장 데이터 sv = SoundVolume
    public float BGV;
    public float effectSV;
}
