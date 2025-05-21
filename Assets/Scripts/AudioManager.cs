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
    public List<AudioSource> audioSources;

    //Make this a list of audio sources
    /*[SerializeField] private AudioSource audioSource;*/

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

    public void PlayHandSound1()
    {
        PlaySound("Hands1");
    }
    public void PlayHandSound2()
    {
        PlaySound("Hands2");
    }
    public void PlayHandSound3()
    {
        PlaySound("Hands3");
    }

    public void PlaySmokePuff()
    {
        PlaySound("Smoke");
    }

    public void PlayDrum()
    {
        PlaySound("Drum");
    }

    private void PlaySound(string targetId)
    {
       
        //Local variable which stores the audiosource we're going to play on
        //go through the list of audio sources (for or foreach loop)
        //Once you have found one that isn't playing - play on that one
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.isPlaying == false)
            {
                /*audioSource.clip = null;*/

                FindSoundWithId(targetId, audioSource);

                if (audioSource.clip == null)
                {
                    return;
                }

                audioSource.Play();

                return;
            }
            
        }

    }
    private void FindSoundWithId(string targetId, AudioSource source)
    {
        foreach (Sound sound in soundList)
        {
            if (sound.id != targetId)
            {
                continue;
            }

            source.clip = sound.clip;
            source.volume = sound.volume;
            break;
        }
    }
}


