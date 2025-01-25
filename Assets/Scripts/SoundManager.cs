using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioSource> auS;
    public List<AudioClip> audioClips;

    private void Start()
    {
        if (audioClips.Count > 0)
            auS[0].PlayOneShot(audioClips[5]); //Musica
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
        if (audioClips.Count > 0)
            auS[0].PlayOneShot(audioClips[3]);
    }

    public void NoWinSound()
    {
        if (audioClips.Count > 0)
            auS[0].PlayOneShot(audioClips[4]);
    }
}
