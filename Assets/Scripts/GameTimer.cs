using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public int totalLevelTime;
	
	private float currentLevelTime;
	private Slider mySlider;
	private LevelManager levelManager;
	private GameObject victoryText;
	private AudioSource victoryAudioSource;
	private bool IsLevelComplete = false;
	
	// Use this for initialization
	void Start () {
		mySlider = GetComponent<Slider>();
		victoryAudioSource = GameObject.Find("VictoryClip").GetComponent<AudioSource>();;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		victoryText = GameObject.Find("VictoryText");
		victoryText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		currentLevelTime = Time.timeSinceLevelLoad;
		float levelCompletionPercentage = currentLevelTime / totalLevelTime;
		mySlider.value = levelCompletionPercentage;
		
		if(levelCompletionPercentage >= 1 && !IsLevelComplete){
			IsLevelComplete = true;
			CompleteLevel();
		}
	}
	
	void CompleteLevel(){
		DestroyAllTaggedObjectsOnWin();
		victoryAudioSource.Play();
		victoryText.SetActive(true);
		Invoke("LoadNextLevel", victoryAudioSource.clip.length);
	
	}
	
	//destory all objects with the destoryOnWin Tag
	void DestroyAllTaggedObjectsOnWin(){
		GameObject[] objectsToDestory = GameObject.FindGameObjectsWithTag("destroyOnWin");
		foreach(GameObject objectToDestory in objectsToDestory){
			Destroy(objectToDestory);
		}
	}
	
	void LoadNextLevel(){
		levelManager.LoadNextLevel();
	}
}
