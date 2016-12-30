using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	private StarDisplay starDisplay;
	
	public int starCost = 50;

	void Start(){
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}

	void AddStars(int amount){
		starDisplay.AddStars(amount);
		return;
	}

}
