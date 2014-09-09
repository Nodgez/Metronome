using UnityEngine;
using System.Collections;

public class Metronome : MonoBehaviour {

	public int tempo = 120;
	public int beatsInBar;
	public int noteValue;
	public AudioClip accent;
	public AudioClip normal;

	private int beatCounter;
	private float timer;
	private float alpha;
	private float interval;

	void Start ()
	{
		interval = 60.0f / (float)tempo;
		Time.fixedDeltaTime = interval;
	}

	void Update()
	{
		if(!IsPowerOfTwo(noteValue))
			noteValue = 4;

		float scaling = (float)4 / (float)noteValue;

		interval = (60.0f * scaling) / (float)tempo;
		Time.fixedDeltaTime = interval;
	}

	void FixedUpdate () 
	{
		audio.clip = beatCounter % beatsInBar == 0 ? accent : normal;
		beatCounter++;

		audio.loop = false;
		audio.Play ();
	}

	bool IsPowerOfTwo(int value)
	{
		return (value != 0) && ((value & (value - 1)) == 0);
	}
}
