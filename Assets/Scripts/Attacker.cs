using UnityEngine;
using System.Collections;


[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

	private float currentSpeed;
	private GameObject currentTarget;
	private Health myHealth;
	private Animator myAnimator;

	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!currentTarget){
			myAnimator.SetBool("isAttacking",false);
		}
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		//Debug.Log("attacker collided with" + collider);
	}
	
	public void SetSpeed(float speed){
		currentSpeed = speed;
	}
	
	public void StrikeCurrentTarget(float damage){
	
		if(currentTarget){
			Health targetHealth = currentTarget.GetComponent<Health>();
				if(targetHealth){
					targetHealth.DealDamage(damage);
				}
		}		
//		currentTarget.GetComponent<Health>().UpdateHealth(-damage);
		//Debug.Log(name + "did " + damage + " damage!");
	}
	
	public void AttackTarget(GameObject targtObject){
		currentTarget = targtObject;
	}
}
