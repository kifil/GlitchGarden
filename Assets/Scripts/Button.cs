using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	private Button[] buttonPanelButtons;
	
	public GameObject defenderPrefab;
	public static GameObject selectedDefender;
	
	void Start () {
		buttonPanelButtons = GameObject.FindObjectsOfType<Button>();
	}
	
	void OnMouseDown(){
		foreach(var buttonPanelButton in buttonPanelButtons){
			buttonPanelButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		
		selectedDefender = defenderPrefab;
		gameObject.GetComponent<SpriteRenderer>().color = Color.white;
	}
}
