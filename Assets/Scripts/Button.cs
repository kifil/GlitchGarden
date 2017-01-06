using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	private Button[] buttonPanelButtons;
	
	public GameObject defenderPrefab;
	public static GameObject selectedDefender;
	private Text costText;
	
	void Start () {
		buttonPanelButtons = GameObject.FindObjectsOfType<Button>();
		costText = GetComponentInChildren<Text>();
		
		if(!costText){
			Debug.LogWarning("missing cost text for button");
		}
		else{
			costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
		}
		
	}
	
	void OnMouseDown(){
		foreach(var buttonPanelButton in buttonPanelButtons){
			buttonPanelButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		
		selectedDefender = defenderPrefab;
		gameObject.GetComponent<SpriteRenderer>().color = Color.white;
	}
}
