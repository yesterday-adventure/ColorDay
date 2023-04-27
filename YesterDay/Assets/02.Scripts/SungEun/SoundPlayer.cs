using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    private GameDataInstance SV;    // soundVolume

    [SerializeField]
    private AudioSource BG;
    [SerializeField]
    private AudioSource sound;

    private void Awake()
    {
        SV = FindObjectOfType<GameDataInstance>();
    }

    /*public void SoundPlay()
    {
        sound.volume = SV.effectSV;     // Ȥ�ø��� �ٽ� ����
        
        sound.Play();
    }*/     // ��ũ��Ʈ���� �ٷ� Ŭ������ �����ϱ�

    // ����Ʈ�� ��������
    public void SetSV(float volume)
    {
        sound.volume = volume;
        SV.effectSV = volume;
    }

    // BG ���� BG�� ����ؼ� ���ؾ� �ϱ� ������ �̷��� ����.
    public void SetBG(float volume)
    {
        BG.volume = volume;
        SV.BGV = volume;    // ������ �޴��� �� ������ �ٲ���
    }
}


// �״ϱ� �̰� Set �޼��� ���� �����̴��� �� �ְ� �����̴� ���� �����ϸ�
// set �޼��尡 ������ �Ǹ鼭 Ŭ���� �ִ°Ͱ� �������ν��Ͻ� ��ũ��Ʈ �ȿ� ���ش�.