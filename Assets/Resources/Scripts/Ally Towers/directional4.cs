using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class directional4 : MonoBehaviour {
	
	public GameObject shootPos1;
	public GameObject shootPos2;
	public GameObject shootPos3;
	public GameObject shootPos4;

	private bool firing;
	private bool temp;
	private List<GameObject> enemies;
	private Object loadBullet;
	
	void Start (){
		enemies = new List<GameObject>();
		firing = false;
		temp = false;
		
		loadBullet = Resources.Load ("Prefabs/Projectiles/Bullet");
	}
	
	void Update () {
		if (firing && temp) {
			StartCoroutine (fire ());
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
		}
	}
	
	private IEnumerator fire(){
		firing = false;
		
		yield return StartCoroutine (wait (1.0f));

		GameObject bullet = Instantiate (loadBullet, shootPos1.transform.position, shootPos1.transform.rotation) as GameObject;
		GameObject bullet2 = Instantiate (loadBullet, shootPos2.transform.position, shootPos2.transform.rotation) as GameObject;
		GameObject bullet3 = Instantiate (loadBullet, shootPos3.transform.position, shootPos3.transform.rotation) as GameObject;
		GameObject bullet4 = Instantiate (loadBullet, shootPos4.transform.position, shootPos4.transform.rotation) as GameObject;
		//bullet = null;
		
		firing = true;
	}
	
	IEnumerator wait(float time){
		yield return new WaitForSeconds (time);
	}
}
