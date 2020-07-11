using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Captain")]
    public Sound[] requestTurnLeft;
    public Sound[] requestTurnRight;
    public Sound[] requestThrottleUp;
    public Sound[] requestThrottleDown;
    public Sound[] prepareTurnLeft;
    public Sound[] prepareTurnRight;
    public Sound[] prepareThrottleUp;
    public Sound[] prepareThrottleDown;

    [Header("Houston")]
    public Sound[] granted;
    public Sound[] denied;
    public Sound[] delay;
    public Sound[] delayYes;
    public Sound[] delayNo;

    [Header("Crew")]
    public Sound[] confirmed;

    [Header("SFX")]
    public Sound[] sounds;

    private void Awake()
    {
        SingletonPattern();
        CreateAudioSources(ref requestTurnLeft);
        CreateAudioSources(ref requestTurnRight);
        CreateAudioSources(ref requestThrottleUp);
        CreateAudioSources(ref requestThrottleDown);
        CreateAudioSources(ref prepareTurnLeft);
        CreateAudioSources(ref prepareTurnRight);
        CreateAudioSources(ref prepareThrottleUp);
        CreateAudioSources(ref prepareThrottleDown);
        CreateAudioSources(ref granted);
        CreateAudioSources(ref denied);
        CreateAudioSources(ref delay);
        CreateAudioSources(ref delayYes);
        CreateAudioSources(ref delayNo);
        CreateAudioSources(ref confirmed);
        CreateAudioSources(ref sounds);
    }

    private void CreateAudioSources(ref Sound[] sounds)
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    private void SingletonPattern()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayRequestLeft()
    {
        int rand = UnityEngine.Random.Range(0, requestTurnLeft.Length);
        Sound s = requestTurnLeft[rand];
        s.source.Play();
    }

    public void PlayRequestRight()
    {
        int rand = UnityEngine.Random.Range(0, requestTurnRight.Length);
        Sound s = requestTurnRight[rand];
        s.source.Play();
    }

    public void PlayRequestUp()
    {
        int rand = UnityEngine.Random.Range(0, requestThrottleUp.Length);
        Sound s = requestThrottleUp[rand];
        s.source.Play();
    }

    public void PlayRequestDown()
    {
        int rand = UnityEngine.Random.Range(0, requestThrottleDown.Length);
        Sound s = requestThrottleDown[rand];
        s.source.Play();
    }

    public void PlayGranted()
    {
        int rand = UnityEngine.Random.Range(0, granted.Length);
        Sound s = granted[rand];
        s.source.Play();
    }

    public void PlayDenied()
    {
        int rand = UnityEngine.Random.Range(0, denied.Length);
        Sound s = denied[rand];
        s.source.Play();
    }

    public void PlayPrepareLeft()
    {
        int rand = UnityEngine.Random.Range(0, prepareTurnLeft.Length);
        Sound s = prepareTurnLeft[rand];
        s.source.Play();
    }

    public void PlayPrepareRight()
    {
        int rand = UnityEngine.Random.Range(0, prepareTurnRight.Length);
        Sound s = prepareTurnRight[rand];
        s.source.Play();
    }

    public void PlayPrepareUp()
    {
        int rand = UnityEngine.Random.Range(0, prepareThrottleUp.Length);
        Sound s = prepareThrottleUp[rand];
        s.source.Play();
    }

    public void PlayPrepareDown()
    {
        int rand = UnityEngine.Random.Range(0, prepareThrottleDown.Length);
        Sound s = prepareThrottleDown[rand];
        s.source.Play();
    }

    public void PlayDelay()
    {
        int rand = UnityEngine.Random.Range(0, delay.Length);
        Sound s = delay[rand];
        s.source.Play();
    }

    public void PlayDelayYes()
    {
        int rand = UnityEngine.Random.Range(0, delayYes.Length);
        Sound s = delayYes[rand];
        s.source.Play();
    }

    public void PlayDelayNo()
    {
        int rand = UnityEngine.Random.Range(0, delayNo.Length);
        Sound s = delayNo[rand];
        s.source.Play();
    }

    public void PlayConfirmed()
    {
        int rand = UnityEngine.Random.Range(0, confirmed.Length);
        Sound s = confirmed[rand];
        s.source.Play();
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
