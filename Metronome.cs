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

	void Start()
	{
		audio.loop = false;
	}

	void Update()
	{
		//check to see if note is an approprate value e.g. whole,2nd,4th,8th,16th,32th notes
		if(!IsPowerOfTwo(noteValue))
			noteValue = 4;

		//set the tempo to act according to the not value
		float scaling = (float)4 / (float)noteValue;

		//set the fixedDeltaTime that plays our metronome in the FixedUpdate
		interval = (60.0f * scaling) / (float)tempo;
		Time.fixedDeltaTime = interval;
	}

	void FixedUpdate () 
	{
		//accent our beat on the 1st hit of every bar
		audio.clip = beatCounter % beatsInBar == 0 ? accent : normal;
		beatCounter++;
	
		audio.Play ();
	}

	//simple metod to check if our value is a power of 2
	bool IsPowerOfTwo(int value)
	{
		return (value != 0) && ((value & (value - 1)) == 0);
	}
}
