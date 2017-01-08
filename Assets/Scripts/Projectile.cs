using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed;
	public float damage;
	public string[] onHitEffects;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * speed * Time.deltaTime;
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		GameObject collisionObject = collider.gameObject;
		
		if(collisionObject.GetComponent<Attacker>() && collisionObject.GetComponent<Health>()){
			var colliderHealth = collisionObject.GetComponent<Health>();
			colliderHealth.DealDamage(this.damage);
			foreach(string onHitEffect in onHitEffects){
				collisionObject.GetComponent<Attacker>().AddEffect(onHitEffect);
			}
			Destroy(gameObject);
		}
	}
	
}
