using UnityEngine;
using System.Collections;

public class SplashScreenController : MonoBehaviour {

	LevelManager levelManager;
	// Use this for initialization
	void Start () {
		GameObject levelManagerObject = GameObject.Find("LevelManager") as GameObject;
		levelManager = levelManagerObject.GetComponent<LevelManager>();
		Invoke("LoadMainMenu",2.5f);
	
	}
	
	void LoadMainMenu(){
		levelManager.LoadNextLevel();
	}
	
}
