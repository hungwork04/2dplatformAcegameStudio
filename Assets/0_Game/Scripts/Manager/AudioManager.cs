using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance;

	[Header("MUSIC SOURCE")]
	public AudioSource musicSource;

	[Space]
	[Header("SOUND SOURCE")]
	public AudioSource[] soundSources;
	public AudioSource[] loopSources;

	private Queue<AudioSource> _queueSources, _queueLoops;
	private Dictionary<AudioClip, AudioSource> _dicLoop = new ();
	
	[Header("GAME_AUDIO")]
	[SerializeField] private AudioClip buttonSound;
	
	private void Awake()
	{
		Instance = this;

		_queueSources = new Queue<AudioSource>(soundSources);
		_queueLoops = new Queue<AudioSource>(loopSources);
	}

	private void Start()
	{
		UpdateMute();
	}

	public void UpdateMute()
	{
		ChangeMusic(!DataController.Setting_Music);
		ChangeSound(!DataController.Setting_SFX);
	}

	private void ChangeMusic(bool isMute)
	{
		if (musicSource != null)
		{
			musicSource.mute = isMute;
		}
	}

	void ChangeSound(bool isMute)
	{
		foreach (var sound in soundSources)
		{
			sound.mute = isMute;
		}
		foreach (var sound in loopSources)
		{
			sound.mute = isMute;
		}
	}

	public virtual void PlayShot(AudioClip clip, float volume = 1f)
	{
		if (clip == null)
		{
			return;
		}
		var source = _queueSources.Dequeue();
		source.volume = volume;
		source.PlayOneShot(clip);
		_queueSources.Enqueue(source);
	}

	public void PlayLoop(AudioClip clip, float volume = 1f)
	{
		if (clip == null || _dicLoop.ContainsKey(clip))
		{
			return;
		}
		var loopSource = _queueLoops.Dequeue();
		loopSource.volume = volume;
		loopSource.clip = clip;
		loopSource.Play();
		_dicLoop.Add(clip, loopSource);
	}

	public void StopLoop(AudioClip clip)
	{
		if (!clip || !_dicLoop.ContainsKey(clip))
		{
			return;
		}
		var loopSource = _dicLoop[clip];
		if (loopSource)
		{
			loopSource.Stop();
			_queueLoops.Enqueue(loopSource);
			_dicLoop.Remove(clip);
		}
	}
	
	public void PlayButtonSound()
	{
		PlayShot(buttonSound);
	}
}


public enum MusicType
{
	Home,
	Gameplay
}