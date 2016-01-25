using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicArray;
	
	private AudioSource myAudioSource;
	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad(gameObject);
		myAudioSource = GetComponent<AudioSource>();
	}
	
	void OnLevelWasLoaded(int level){
		AudioClip thisLevelAudio = levelMusicArray[level];
		
		if(thisLevelAudio){
			myAudioSource.clip = thisLevelAudio;
			myAudioSource.Play();
		}
		else{
			myAudioSource.Stop();
		}
	}
	
}
