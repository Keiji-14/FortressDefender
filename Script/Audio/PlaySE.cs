using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ʉ��̊Ǘ�
/// </summary>
public class PlaySE : MonoBehaviour
{
    [Header("AudioClip")]
    [SerializeField] AudioClip buttonSE;
    [SerializeField] AudioClip shotSE;
    [SerializeField] AudioClip destroySE;
    [Header("AudioVolume")]
    private const float buttonVolume = 0.5f;
    private const float shotVolume = 0.2f;
    private const float destroyVolume = 0.2f;
    [Header("AudioSource")]
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    // �{�^�����������Ƃ��̌��ʉ�
    public void ButtonSE()
    {
        audioSource.PlayOneShot(buttonSE);
        audioSource.volume = buttonVolume;
    }

    // �e�𔭎˂������̌��ʉ�
    public void ShotSE()
    {
        audioSource.PlayOneShot(shotSE);
        audioSource.volume = shotVolume;
    }

    // �~�T�C�������ł��鎞�̌��ʉ�
    public void DestroySE()
    {
        audioSource.PlayOneShot(destroySE);
        audioSource.volume = destroyVolume;
    }
}
