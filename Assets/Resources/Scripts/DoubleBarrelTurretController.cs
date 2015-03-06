using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoubleBarrelTurretController : MonoBehaviour {

	public GameObject shootPos1;
	public GameObject shootPos2;
	private GameObject rotPoint;
	public float rotateSpeed = 5.0f;

	private bool firing = false;
	private bool temp = false;
	private List<GameObject> enemies;
	public GameObject target;

	void Start (){
		enemies = new List<GameObject>();
		target = null;
		rotPoint = GameObject.Find ("turretTop");
	}

	void Update () {
		if (firing && temp) {
			StartCoroutine (fire ());
		} else if (enemies.Count > 0 && target == null) {
			Debug.Log ("Target acquired");
			target = enemies [0].gameObject;
		} else if (target != null) {
			rotateCannon ();
		} 

		if (enemies.Count <= 0 && !firing && !temp) {
			Debug.Log("Lost target");
			target = null;
		}
	}

	void OnTriggerEnter(Collider c){
		if (c.transform.tag == "Enemy") {
			enemies.Add(c.gameObject);
			if(enemies.Count > 0 && temp == false){
				firing = true;
				temp = true;
			}
		}
	}

	void OnTriggerExit(Collider c){
		if (c.transform.tag == "Enemy") {
			enemies.Remove(c.gameObject);
			if(enemies.Count <= 0){
				Debug.Log("not firing");
				firing = false;
				temp = false;
			}
		}
	}

	private IEnumerator fire(){
		firing = false;

		yield return StartCoroutine (wait (1.0f));

		if (target != null) {
			GameObject bullet = Instantiate (Resources.Load ("Prefabs/Bullet"), shootPos1.transform.position, shootPos1.transform.rotation) as GameObject;
			bullet.SendMessage ("set_target", target);
			bullet = Instantiate (Resources.Load ("Prefabs/Bullet"), shootPos2.transform.position, shootPos2.transform.rotation) as GameObject;
			bullet.SendMessage ("set_target", target);
			bullet = null;
		}


		firing = true;
	}

	IEnumerator wait(float time){
		yield return new WaitForSeconds (time);
	}

	private void rotateCannon(){
		/*float dx = target.transform.position.x - transform.position.x;
		float dy = target.transform.position.y - transform.position.y;

		float radians = Mathf.Atan2 (dy, dx);
		float angle = radians * 180.0f / Mathf.PI;

		float rotateY = Mathf.LerpAngle(transform.rotation.x, angle, Time.time);
		
		transform.eulerAngles = new Vector3(transform.rotation.x, rotateY, transform.rotation.z);*/

		Quaternion lookAtRotation = Quaternion.LookRotation(target.transform.position - transform.position);
		// Will assume you mean to divide by damping meanings it will take damping seconds to face target assuming it doesn't move
		rotPoint.transform.rotation = Quaternion.Slerp(rotPoint.transform.rotation, lookAtRotation, Time.deltaTime * rotateSpeed);

	}

}
