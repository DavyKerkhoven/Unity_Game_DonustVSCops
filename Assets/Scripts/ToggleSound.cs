using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSound : MonoBehaviour 
{
	AudioSource audio;
	// Use this for initialization
	void Start () 
	{
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ToggleAudio()
	{
		if (audio.isPlaying)
		{
			audio.Pause ();
		}
		else
		{
			audio.UnPause ();
		}
	}
}
