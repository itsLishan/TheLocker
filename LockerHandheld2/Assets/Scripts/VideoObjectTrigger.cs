using UnityEngine;
using System.Collections;

public class VideoObjectTrigger : MonoBehaviour {

	public GameObject videoObject;
	public float videoTriggerTime;
	
	private float startTime;
	private float elapsedTime;
	private bool isBeingTracked;
	private AudioSource audio;
	
	// Use this for initialization
	void Start () {
		
		audio = GameObject.FindGameObjectWithTag ("Audio").GetComponent<AudioSource>();
		if (videoObject != null) {
			//videoObject.SetActive (false);
		} 
		else {
			Debug.LogError("There is no video object, please assign it to me!");
		}
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
			if( audio != null ) audio.Play ();
		}
	}
	
	void EndTrackingTimer(){
		isBeingTracked = false;
		elapsedTime = 0f;
		if( audio != null ) audio.Stop ();
	}
	
	void StartVideo(){
		isBeingTracked = false;
		if (videoObject != null) {
			videoObject.SetActive(true);
			videoObject.GetComponent<VideoTexture_Lite>().enabled = true;
		}
		//Handheld.PlayFullScreenMovie (videoName, Color.black, FullScreenMovieControlMode.Hidden);
	}
}
