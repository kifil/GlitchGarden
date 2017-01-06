using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera gameCamera;

	private GameObject parentGameObject;
	private StarDisplay starDisplay;
	
	void Start(){
		parentGameObject = GameObject.Find("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		
		if(parentGameObject == null){
			parentGameObject = new GameObject("Defenders");
		}
		
	}
	
	void OnMouseDown(){
		Vector2 rawWorldPosition = CalculateWorldPointOfMoustClick();
		Vector2 roundedWorldPosition = SnapToGrid(rawWorldPosition);
		GameObject selectedDefender = Button.selectedDefender;
	
		//no defender selected, don't try to spawn
		if(!selectedDefender){
			return;
		}
		
		int defenderCost = selectedDefender.GetComponent<Defender>().starCost;
		
		if(starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS){
			SpawnNewDefender(roundedWorldPosition, selectedDefender);
		}
		else{
			print ("Insufficient stars to spawn");
		}
	

	}
	
	void SpawnNewDefender(Vector2 roundedWorldPosition, GameObject defender){
		GameObject newDefender = GameObject.Instantiate(Button.selectedDefender,roundedWorldPosition,Quaternion.identity) as GameObject;
		
		newDefender.transform.parent = parentGameObject.transform;
	}
	
	Vector2 SnapToGrid( Vector2 rawWorldPositon){
		float roundedX = Mathf.RoundToInt(rawWorldPositon.x);
		float roundedY = Mathf.RoundToInt(rawWorldPositon.y);
		
		return new Vector2(roundedX,roundedY);
	}
	
	Vector2 CalculateWorldPointOfMoustClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY  = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector3 mousePositionVector = new Vector3(mouseX,mouseY,distanceFromCamera);
	
		return gameCamera.ScreenToWorldPoint(mousePositionVector);
	}
}
