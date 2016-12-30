using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text myText;
	private int currentStarCount = 100;
	
	public enum Status {SUCCESS,FAILURE};
	
	void Start(){
		myText = GetComponent<Text>();
		UpdateTextDisplay();
	}

	public void AddStars(int amount){
		currentStarCount += amount;
		UpdateTextDisplay();
	}
	
	public Status UseStars(int amount){
		if(currentStarCount >= amount){
			currentStarCount -= amount;
			UpdateTextDisplay();
			return Status.SUCCESS;
		}
		
		return Status.FAILURE;

	}
	
	private void UpdateTextDisplay(){
		myText.text = currentStarCount.ToString();
	}

}
