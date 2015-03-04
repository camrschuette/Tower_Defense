using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoubleBarrelTurretController : MonoBehaviour {

	public GameObject shootPos1;
	public GameObject shootPos2;

	private bool firing = false;
	private bool temp = false;
	private List<GameObject> enemies;

	void Start (){
		enemies = new List<GameObject>();
		Debug.Log (enemies.Count);
	}

	void Update () {
		if (firing && temp) {
			StartCoroutine(fire());
		}

		Debug.Log (enemies.Count);
	}

	void OnTriggerEnter(Collider c){
		Debug.Log("enter");
		if (c.transform.tag == "Enemy") {
			enemies.Add(c.gameObject);
			if(enemies.Count > 0 && temp == false){
				firing = true;
				temp = true;
			}
		}
	}

	void OnTriggerExit(Collider c){
		Debug.Log("exit");
		if (c.transform.tag == "Enemy") {
			enemies.Remove(c.gameObject);
			if(enemies.Count <= 0){
				firing = false;
				temp = false;
			}
		}
	}

	private IEnumerator fire(){
		firing = false;
		yield return StartCoroutine (wait ());

		GameObject bullet = Instantiate (Resources.Load("Prefabs/Bullet"), shootPos1.transform.position, transform.rotation) as GameObject;
		bullet = Instantiate (Resources.Load("Prefabs/Bullet"), shootPos2.transform.position, transform.rotation) as GameObject;
		bullet = null;

		firing = true;
	}

	IEnumerator wait(){
		yield return new WaitForSeconds (1.0f);
	}
}
