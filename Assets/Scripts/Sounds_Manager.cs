using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sounds_Manager : MonoBehaviour
{
    private static bool destroy = false;
    public static Sounds_Manager instance;
    public AudioSource audioSource;
    public AudioSource sfxSource;

    public AudioClip bgClip;
    public AudioClip clickClip;
    private void Awake()
    {
        if (!destroy)
        {
            DontDestroyOnLoad(this.gameObject);
            destroy = true;
        }
    }
    void Start()
    {
        if (instance == null) instance = this;
        audioSource.volume = 0.2f;
        audioSource.clip = bgClip;
        audioSource.Play();
    }
    public void SFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    public void OnClick_Play()
    {
        SFX(clickClip);
        SceneManager.LoadScene(1);
    }
}
