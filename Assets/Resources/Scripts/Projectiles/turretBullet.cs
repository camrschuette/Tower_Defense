using UnityEngine;
using System.Collections;

public class turretBullet : MonoBehaviour {

	public float speed = 30.0f;
	public float damage = 0.0f;
	
	public GameObject target;

	void Start(){
		Destroy (gameObject, 3.0f);
	}

	void FixedUpdate () {
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, speed * Time.deltaTime); 
	}

	void OnTriggerEnter(Collider obj){
		if (obj.transform.tag == "Enemy") {
			Destroy(gameObject);
			transform.parent.gameObject.SendMessage("remove_enemy", obj.gameObject);
			obj.gameObject.SendMessage("take_Damage", damage);
		}
	}

	public void set_target(GameObject t){
		target = t;
	}

	private void set_damage(float amt){
		damage = amt;
	}
	
}
