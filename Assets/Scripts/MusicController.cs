using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip MenuTheme;
    public AudioClip GameTheme;
    public AudioClip WinTheme;
    public AudioClip LossTheme;
    public AudioSource source;

    public void PlayMenu()
    {
        source.clip = MenuTheme;
        source.Play();
    }

    public void PlayGame()
    {
        source.clip = GameTheme;
        source.Play();
    }

    public void PlayWin()
    {
        source.clip = WinTheme;
        source.Play();
    }

    public void PlayLoss()
    {
        source.clip = LossTheme;
        source.Play();
    }

}
