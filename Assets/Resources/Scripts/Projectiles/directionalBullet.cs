using UnityEngine;
using System.Collections;

public class directionalBullet : MonoBehaviour {

	public float speed = 30.0f;
	
	void Start(){
		Destroy (gameObject, 5.0f);
	}
	
	void Update () {
		transform.Translate(transform.forward * speed * Time.deltaTime);
		Debug.Log(transform.forward);
	}
}
