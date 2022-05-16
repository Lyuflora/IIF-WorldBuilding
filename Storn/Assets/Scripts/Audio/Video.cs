
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.Video;

[System.Serializable]
public class Video
{

	public string name;

	public VideoPlayer player;

	[Range(0f, 1f)]
	public float volume = .75f;
	[Range(0f, 1f)]
	public float volumeVariance = .1f;

	[Range(.1f, 3f)]
	private float pitch = 1f;
	[Range(0f, 1f)]
	private float pitchVariance = .1f;

	public bool loop = false;


}