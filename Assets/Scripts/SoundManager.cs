using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioSource> auS;
    public List<AudioClip> audioClips;

    private void Start()
    {
        if (audioClips.Count > 0)
        {
            auS[0].clip = audioClips[5];
            auS[0].Play(); //Musica
        }         
    }

    public void accelerateMusic()
    {
        auS[0].pitch = 1.5f;
    }

    public void FinishSound()
	{
        if (audioClips.Count > 0)
            auS[1].PlayOneShot(audioClips[0]);
	}

    public void CoinSound()
    {
        if (audioClips.Count > 0)
            auS[1].PlayOneShot(audioClips[1]);
    }

    public void PopSound()
    {
        if (audioClips.Count > 0)
            auS[1].PlayOneShot(audioClips[2]);
    }

    public void WinSound()
    {
        auS[0].loop = false;
        auS[0].pitch = 1f;
        if (audioClips.Count > 0)
            auS[0].PlayOneShot(audioClips[3]);
    }

    public void NoWinSound()
    {
        auS[0].loop = false;
        auS[0].pitch = 1f;
        if (audioClips.Count > 0)
            auS[0].PlayOneShot(audioClips[4]);
    }
}
