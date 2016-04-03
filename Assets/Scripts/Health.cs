using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float currentHealth;

	// Use this for initialization
	void Start () {
	
	}

	public void DealDamage(float damage){
		currentHealth -= damage;
		if(currentHealth <=0 ){
		//optionally trigger death animation
			DestoryObject();
		}
	}
	
	//could call this from animator death animation instead
	public void DestoryObject(){
		Destroy(gameObject);
	}
}
	
