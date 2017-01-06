using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

	private Animator myAnimator;

	void Start(){
		myAnimator = GetComponent<Animator>();
	}

	void OnTriggerStay2D(Collider2D collider){
		if(collider.GetComponent<Attacker>()){
			myAnimator.SetTrigger("underAttackTrigger");
		}
	}
}
