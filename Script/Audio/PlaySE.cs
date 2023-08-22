using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 効果音の管理
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

    // ボタンを押したときの効果音
    public void ButtonSE()
    {
        audioSource.PlayOneShot(buttonSE);
        audioSource.volume = buttonVolume;
    }

    // 弾を発射した時の効果音
    public void ShotSE()
    {
        audioSource.PlayOneShot(shotSE);
        audioSource.volume = shotVolume;
    }

    // ミサイルが消滅する時の効果音
    public void DestroySE()
    {
        audioSource.PlayOneShot(destroySE);
        audioSource.volume = destroyVolume;
    }
}
