﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attacker))]
public class Juju : MonoBehaviour {
	
	private Attacker myAttacker;
	private Animator myAnimator;
	
	void Start () {	
		myAttacker = GetComponent<Attacker>();
		myAnimator = GetComponent<Animator>();
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		
		GameObject collisionObject = collider.gameObject;
		
		if(collisionObject.GetComponent<Defender>()){
			myAnimator.SetBool("isAttacking",true);
			myAttacker.SetTarget(collisionObject);
		}
	}
}
