using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile,gun;
	
	private GameObject projectileParent;
	private Animator myAnimator;
	private Spawner myLaneSpawner;
	
	void Start(){
		SetMyLaneSpawner();
		myAnimator = this.GetComponent<Animator>();
		
		//create a parent object to nest projectiles
		projectileParent = GameObject.Find("Projectiles");
		if(projectileParent == null){
			projectileParent = new GameObject("Projectiles");
		}
	
	}
	
	void SetMyLaneSpawner(){
		Spawner[] allSpawners = GameObject.FindObjectsOfType<Spawner>();
		
		foreach(Spawner spawner in allSpawners){
			if(spawner.transform.position.y == this.transform.position.y){
				myLaneSpawner = spawner;
				return;
			}
		}
		
		if(!myLaneSpawner){
			Debug.LogError("Unable to find spawner for lane: " + this.transform.position.y);
		}
	}
	
	void Update(){
		if(IsAttackerAheadInLane()){
			myAnimator.SetBool("IsAttacking", true);
		}
		else{
			myAnimator.SetBool("IsAttacking", false);
		}
	
	}
	
	bool IsAttackerAheadInLane(){
		if(myLaneSpawner.transform.childCount == 0){
			return false;
		}
		
		foreach(Attacker attacker in myLaneSpawner.GetComponentsInChildren<Attacker>()){
			if(attacker.transform.position.x > this.transform.position.x){
				return true;
			}
		}
		
		return false;	
	}
	
	public void Fire(){
		GameObject newProjectile = (GameObject)Instantiate(projectile);
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
