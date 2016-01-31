using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;
	
	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	
		musicManager = GameObject.FindObjectOfType<MusicManager>();
	}
	
	// Update is called once per frame
	void Update () {

//		musicManager.SetVolume(volumeSlider.value);
	}
	
	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(Mathf.FloorToInt(difficultySlider.value));
		
		var thing =PlayerPrefsManager.GetMasterVolume();
		
		musicManager.SetVolume(volumeSlider.value);
		
		levelManager.LoadLevel("Start");
	}
	
	public void SetDefault(){
		volumeSlider.value = .8f;
		difficultySlider.value = 2;
	}
}
