using UnityEngine;
using System.Collections;


[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between spawns")]
	public float seenEverySeconds;

	private float currentSpeed;
	private GameObject currentTarget;
	private Health myHealth;
	private Animator myAnimator;
	private SpriteRenderer mySpriteRenderer;

	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator>();
		mySpriteRenderer = this.transform.FindChild("Body").GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!currentTarget){
			myAnimator.SetBool("isAttacking",false);
		}
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		
		if(gameObject.GetComponent<SlowEffect>()){
			mySpriteRenderer.color = Color.cyan;
			//SetSpeed(currentSpeed);
		}
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		//Debug.Log("attacker collided with" + collider);
	}
	
	public void SetSpeed(float speed){
		currentSpeed = speed;
		
		SlowEffect slowEffect = gameObject.GetComponent<SlowEffect>();
		if(slowEffect){
			currentSpeed = speed * slowEffect.GetSlowAmount();
		}
	}
	
	public void StrikeCurrentTarget(float damage){
		if(currentTarget){
			Health targetHealth = currentTarget.GetComponent<Health>();
				if(targetHealth){
					targetHealth.DealDamage(damage);
				}
		}		
	}
	
	public void SetTarget(GameObject targtObject){
		currentTarget = targtObject;
	}
	
	public void AddEffect(string componentName){
		if(this.GetComponent(componentName)){
			Destroy(this.GetComponent(componentName));
		}
		
		var newComponent = UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(gameObject, "Assets/Scripts/Attacker.cs (67,22)", componentName);
	}
}
