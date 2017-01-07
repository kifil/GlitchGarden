using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

	[Tooltip("Amount of free stars given every tick")]
	public int freeStarsPerTick = 10;

	private Text myText;
	private int currentStarCount = 100;
	private float timeSinceLastStarIncome = 0f;
	
	public enum Status {SUCCESS,FAILURE};
	
	void Start(){
		myText = GetComponent<Text>();
		UpdateTextDisplay();
	}
	
	void Update(){
		AddFreeStars();
	}
	
	private void AddFreeStars(){
		timeSinceLastStarIncome += Time.deltaTime;
		if(timeSinceLastStarIncome >= 5){
			AddStars(freeStarsPerTick);
			timeSinceLastStarIncome = 0;
		}
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
