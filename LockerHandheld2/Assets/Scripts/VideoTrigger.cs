using UnityEngine;
using System.Collections;

public class VideoTrigger : MonoBehaviour {

	public float videoTriggerTime;

	public string videoName;

	private float startTime;
	private float elapsedTime;
	private bool isBeingTracked;
	private AudioSource audio;
	
	// Use this for initialization
	void Start () {

		audio = GameObject.FindGameObjectWithTag ("Audio").GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isBeingTracked){
			elapsedTime = Time.time - startTime;
			if (elapsedTime >= videoTriggerTime)
				StartVideo();
		}
	
	}

	void StartTrackingTimer(float myStartTime){
		if (isBeingTracked == false) {
			isBeingTracked = true;
			startTime = myStartTime;
			audio.Play ();
		}
	}

	void EndTrackingTimer(){
		isBeingTracked = false;
		elapsedTime = 0f;
		audio.Stop ();
	}

	void StartVideo(){
		isBeingTracked = false;
		Handheld.PlayFullScreenMovie (videoName, Color.black, FullScreenMovieControlMode.Hidden);

	}

}
