using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed;
	public float damage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * speed * Time.deltaTime;
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log("Projectile collided with" + collider);
	}
	
	void OnBecaomeInvisible(){
		Destroy(gameObject);
	}
}
