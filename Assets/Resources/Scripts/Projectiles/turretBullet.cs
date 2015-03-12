using UnityEngine;
using System.Collections;

public class turretBullet : MonoBehaviour {

	public float speed = 30.0f;
	
	public GameObject target;

	void Start(){
		Destroy (gameObject, 5.0f);
	}

	void FixedUpdate () {
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, speed * Time.deltaTime); 
	}

	public void set_target(GameObject t){
		target = t;
	}
}
