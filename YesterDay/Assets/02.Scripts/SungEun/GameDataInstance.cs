using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataInstance : MonoBehaviour
{
    // �̱������� ���� ���� �� ���� �ÿ��� ������ �����ϵ���
    // �ϴ� ù��°�� ����

    #region awake ����� �̱���
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
        // ���� ���� ������ �ν��Ͻ��� ���ٸ�
        if (instance == null)
        {
            instance = this;
            // �̰ɷ� ���ش�.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // ������ �����ش�.
            Destroy(this.gameObject);
        }
    }
    #endregion

    // ���� ������ sv = SoundVolume
    public float BGV;
    public float effectSV;
}
