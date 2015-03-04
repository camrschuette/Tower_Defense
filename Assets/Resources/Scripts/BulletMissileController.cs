using UnityEngine;
using System.Collections;

public class BulletMissileController : MonoBehaviour {

	public float speed = 15.0f;

	void Start(){
		Destroy (gameObject, 5.0f);
	}

	void Update () {
		gameObject.transform.Translate(transform.forward * speed * Time.deltaTime);
	}
}
