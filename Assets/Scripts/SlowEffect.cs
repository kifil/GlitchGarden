using UnityEngine;
using System.Collections;

public class SlowEffect : MonoBehaviour {

	public float slowDuration = 4;
	public float slowPercentage  = 0.3f;
	
	private float remainingSlowDuration;

	// Use this for initialization
	void Start () {
		remainingSlowDuration = slowDuration;
	}
	
	// Update is called once per frame
	void Update () {
		remainingSlowDuration -= Time.deltaTime;
		
		if(remainingSlowDuration <= 0){
			Destroy(this);
		}
	}
	
	public float GetSlowAmount(){
		return 1 - slowPercentage;
	}
}
