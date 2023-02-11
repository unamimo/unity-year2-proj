using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioControl : MonoBehaviour
{

    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
        }
    }

    // Update is called once per frame
    public void Play(string name, bool isLoop)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (isLoop == true)
        {
            s.source.loop = true;
        }
        s.source.Play();
    }
}
