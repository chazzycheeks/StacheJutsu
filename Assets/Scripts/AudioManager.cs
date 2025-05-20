using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]
    public struct Sound
    {
        public string id;
        public AudioClip clip;
        [Range(0f, 1f)] public float volume;

    }
public class AudioManager : MonoBehaviour
{
    public List<Sound> soundList;

    [SerializeField] private AudioSource audioSource;

    public void PlayDoorbell()
    {
        PlaySound("DoorRing");
    }
    public void PlayProgressDing()
    {
        PlaySound("ProgressDing");
    }

    public void PlayHajime()
    {
        PlaySound("Hajime");
    }

    public void PlayFail()
    {
        PlaySound("Fail");
    }

    public void PlayHandSound()
    {
        PlaySound("Hands");
    }

    public void PlaySmokePuff()
    {
        PlaySound("Smoke");
    }

    private void PlaySound(string targetId)
    {
        audioSource.clip = null;

        FindSoundWithId(targetId);

        if (audioSource.clip == null)
        {
            return;
        }

        audioSource.Play();
    }
    private void FindSoundWithId(string targetId)
    {
        foreach (Sound sound in soundList)
        {
            if (sound.id != targetId)
            {
                continue;
            }

            audioSource.clip = sound.clip;
            audioSource.volume = sound.volume;
            break;
        }
    }
}


