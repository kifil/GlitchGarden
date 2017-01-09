using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicArray;
	
	private AudioSource myAudioSource;
	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad(gameObject);
		myAudioSource = GetComponent<AudioSource>();
		myAudioSource.volume = PlayerPrefsManager.GetMasterVolume();
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
	
	public void SetVolume(float volume){
		myAudioSource.volume = volume;
	}
	
}
