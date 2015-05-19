using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class boostTower : towerBase {

	private List<GameObject> towers;

	void Start(){
		towers = new List<GameObject> ();
	}

	void OnTriggerEnter(Collider obj){
		GameObject ally = obj.transform.parent.gameObject;

		towers.Add (ally);
		ally.SendMessage ("boost", 0.05f);
	}

	void OnTriggerExit(Collider obj){
		Debug.Log ("Something left");
	}

	public override void take_Damage(float amt){
		health = health - amt;
		
		if (health <= 0.0f) {
			health = 0.0f;
			Destroy(gameObject); //for right now we will just destroy the gameobject

			/*here is where we can go through list of towers and destroy their boosts*/
		}
	}

	//still need a way if this tower is destroyed to take away boosts
}
