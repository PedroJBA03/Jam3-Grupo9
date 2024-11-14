using System.Collections.Generic;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } // Singleton instance

    [Header("Audio Sources")]
    public AudioSource backgroundMusicSource; // Drag Background Music's AudioSource
    public AudioSource sfxSource; // Drag SFX's AudioSource
    [Header("Audio Clips")]
    public List<AudioClip> backgroundMusicClips; // List of background music clips for random play
    public List<AudioClip> winSFXClips; // List of win SFX clips
    public List<AudioClip> loseSFXClips; // List of lose SFX clips
    [Header("Team Win Clips")]
    public AudioClip redTeamWinClip;             // Sound for red team win
    public AudioClip blueTeamWinClip;            // Sound for blue team win

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            PlayRandomBackgroundMusic(); // Mueve la llamada aquí
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Play random background music from the list
    public void PlayRandomBackgroundMusic()
    {
        if (backgroundMusicSource.isPlaying) return; // Si ya se está reproduciendo, no reiniciar

        if (backgroundMusicClips.Count > 0)
        {
            AudioClip randomClip = backgroundMusicClips[Random.Range(0, backgroundMusicClips.Count)];
            backgroundMusicSource.clip = randomClip;
            backgroundMusicSource.loop = true;
            backgroundMusicSource.Play();
        }
    }
    // Play random SFX clip for a win
    public void PlayWinSFX()
    {
        PlayRandomSFX(winSFXClips);
    }
    // Play random SFX clip for a loss
    public void PlayLoseSFX()
    {
        PlayRandomSFX(loseSFXClips);
    }
    // Generic method to play a random clip from a given list
    // Generic method to play a random clip from a given list
    private void PlayRandomSFX(List<AudioClip> sfxClips)
    {
        if (sfxClips.Count > 0)
        {
            AudioClip randomClip = sfxClips[Random.Range(0, sfxClips.Count)];
            sfxSource.PlayOneShot(randomClip);
        }
    }
    // New method to play win SFX for specific teams
    public void PlayRedTeamWinSFX()
    {
        if (redTeamWinClip != null)
        {
            sfxSource.PlayOneShot(redTeamWinClip);
        }
        else
        {
            Debug.LogWarning("Red team win clip not assigned in the Inspector.");
        }
    }

    // Play specific win SFX for blue team
    public void PlayBlueTeamWinSFX()
    {
        if (blueTeamWinClip != null)
        {
            sfxSource.PlayOneShot(blueTeamWinClip);
        }
        else
        {
            Debug.LogWarning("Blue team win clip not assigned in the Inspector.");
        }
    }
}