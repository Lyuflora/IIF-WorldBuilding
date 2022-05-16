using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.Video;

public class AudioManager : MonoBehaviour
{

	public static AudioManager m_Instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;
	public Video[] videos;

	public bool waitForInput;
    private void Start()
    {

		// Play("Theme");
		Debug.Log("Start");
		if (!waitForInput)
        {
			PlayAllVideos();
        }

	}
    void Awake()
	{
		//m_Instance = this;
		if (m_Instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			m_Instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}

		Debug.Log("Set Volume");
		SetVideoVolume(videos);
	}
    private void Update()
    {
        if (waitForInput)
        {
			if (Input.GetKeyDown(KeyCode.P))
			{
				PlayAllVideos();

			}
		}

    }
    public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}
	public void SetVideoVolume(Video[] videos)
    {
		foreach (Video v in videos)
        {
			v.player.SetDirectAudioVolume(0, v.volume);
			v.player.SetDirectAudioVolume(1, v.volume);
			Debug.Log("Volume set " + v);
		}
    }
	public void PlayAllVideos()
    {
		foreach (Video v in videos)
		{
			v.player.Play();
		}

    }
}
