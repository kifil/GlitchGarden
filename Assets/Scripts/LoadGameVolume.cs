using UnityEngine;
using System.Collections;

public class LoadGameVolume : MonoBehaviour {

	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		musicManager = FindObjectOfType<MusicManager>();
		musicManager.SetVolume(PlayerPrefsManager.GetMasterVolume());
	}
	
}
