﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
	private AudioSource audioSource;

    void Awake()
    {
		audioSource = GetComponent<AudioSource>();
    }

   public void PlayAudio(AudioClip clip)
	{
		audioSource.PlayOneShot(clip);
	}
}
