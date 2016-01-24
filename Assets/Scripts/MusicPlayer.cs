using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	static MusicPlayer instance = null;
	
	public AudioClip splashClip;
	public AudioClip startClip;
	public AudioClip gameClip;
	
	private AudioSource myAudioSource;
	
	void Awake (){
		if(instance != null){
			Destroy(gameObject);
		}
		//else this is the first music player
		else{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			myAudioSource = GetComponent<AudioSource>();
			//default clip
			myAudioSource.clip = splashClip;
			myAudioSource.loop = false;
			myAudioSource.Play();
		}
	}
	
	//build in function that is called when a level is changed
	void OnLevelWasLoaded(int level){
	//TODO: clean this whole file up
		myAudioSource.loop = true;
		if(myAudioSource){
			myAudioSource.Stop();
		
//			if(level == 0){
//				myAudioSource.clip = startClip;
//			}
			if(level == 1){
				myAudioSource.clip = gameClip;
			}
			else if(level == 2){
				myAudioSource.clip = gameClip;
			}
		
			myAudioSource.Play();
		}
	}


}
