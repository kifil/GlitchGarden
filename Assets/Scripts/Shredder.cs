using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	void OnTriggerEnter2D(Collider collider){
		Destroy(collider.gameObject);
	}
}
