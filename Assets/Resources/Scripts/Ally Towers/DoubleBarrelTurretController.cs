using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoubleBarrelTurretController : MonoBehaviour {

	public GameObject shootPos1;
	public GameObject shootPos2;
	public GameObject target;
	public float rotateSpeed = 5.0f;
	public GameObject rotPoint;

	private bool firing;
	private bool temp;
	private List<GameObject> enemies;
	private Object loadBullet;

	void Start (){
		enemies = new List<GameObject>();
		firing = false;
		temp = false;
		target = null;

		loadBullet = Resources.Load ("Prefabs/Projectiles/Bullet");
	}

	void Update () {
		if (firing && temp) {
			StartCoroutine (fire ());
		} 

		if (enemies.Count > 0 && target == null) {
			target = enemies [0].gameObject;
		} 

		if (target != null) {
			rotateCannon ();
		} 

		if (enemies.Count <= 0 && !firing && !temp) {
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
				firing = false;
				temp = false;
			}
			else{
				target = enemies[0].gameObject;
			}
		}
	}

	private IEnumerator fire(){
		firing = false;

		yield return StartCoroutine (wait (1.0f));

		if (target != null) {
			GameObject bullet = Instantiate (loadBullet, shootPos1.transform.position, shootPos1.transform.rotation) as GameObject;
			bullet.SendMessage ("set_target", target);
			bullet = Instantiate (loadBullet, shootPos2.transform.position, shootPos2.transform.rotation) as GameObject;
			bullet.SendMessage ("set_target", target);
			bullet = null;
		}


		firing = true;
	}

	IEnumerator wait(float time){
		yield return new WaitForSeconds (time);
	}

	private void rotateCannon(){

		Quaternion lookAtRotation = Quaternion.LookRotation(target.transform.position - transform.position);

		Quaternion tmp = Quaternion.Slerp(rotPoint.transform.rotation, lookAtRotation, Time.deltaTime * rotateSpeed);

		rotPoint.transform.rotation = new Quaternion (rotPoint.transform.rotation.x, tmp.y, rotPoint.transform.rotation.z, rotPoint.transform.rotation.w);

	}

}
