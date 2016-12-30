using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabs;
	public int numberOfLanes;
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject attacker in attackerPrefabs){
			if(IsTimeToSpawn(attacker)){
				Spawn(attacker);
			}
		}
	}
	
	bool IsTimeToSpawn(GameObject attacker){
		float meanSecondsPerSpawn = attacker.GetComponent<Attacker>().seenEverySeconds;
		
		if(Time.deltaTime > meanSecondsPerSpawn){
			Debug.Log ("spawning capped by frame rate");
		}
		
		float meanSpawnsPerSecond = 1 / meanSecondsPerSpawn;
		float meanSpawnsPerSecondPerLane = meanSpawnsPerSecond / numberOfLanes;
		
		float probabilityOfSpawnThisFrame = meanSpawnsPerSecondPerLane * Time.deltaTime;
		
		if(Random.value < probabilityOfSpawnThisFrame){
			return true;
		}
		else{
			return false;
		}
	}
	
	void Spawn(GameObject objectToSpawn){
		GameObject newAttacker = (GameObject)Instantiate(objectToSpawn,gameObject.transform.position,Quaternion.identity);
		newAttacker.transform.parent = this.transform;
	
	}
}
