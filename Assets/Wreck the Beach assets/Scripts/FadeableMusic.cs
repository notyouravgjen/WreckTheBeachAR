using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeableMusic : MonoBehaviour {

	public AudioSource music;

	private float fadeTarget;

	private float fadeFactor;

	void Start ()
	{
		fadeTarget = music.volume;
		fadeFactor = 0.01f;
	}

	void Update ()
	{
		float delta = music.volume - fadeTarget;

		// Fade out
		if (delta > 0.01f)
		{
			music.volume -= fadeFactor;
		}

		// Fade in
		else if (delta < -0.01f)
		{
			music.volume += fadeFactor;
		}
	}

	public void SetFadeTarget(float target)
	{
		fadeTarget = target;
	}
}
