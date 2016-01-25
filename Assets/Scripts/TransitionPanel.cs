using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TransitionPanel : MonoBehaviour {

	public float fadeInTime;

	private Image myImage;
	private float currentAlpha = 1;
	// Use this for initialization
	void Start () {
		myImage = GetComponent<Image>();
		myImage.color = new Color(0,0,0,currentAlpha);
//		InvokeRepeating("FadeIn",0.0001f,.1f);
	}
	
	void Update(){
		if(Time.timeSinceLevelLoad < fadeInTime){
			float fadeInPercent = Time.timeSinceLevelLoad / fadeInTime;
			myImage.color = new Color(0,0,0,1 - fadeInPercent);
		}
		else{
			gameObject.SetActive(false);
		}
	
	}
	
//	void FadeIn(){
//		currentAlpha-=.02f;
//		myImage.color = new Color(0,0,0,currentAlpha);
//		if(currentAlpha <=0){
//			Destroy(this);
//		}
//	}
}
