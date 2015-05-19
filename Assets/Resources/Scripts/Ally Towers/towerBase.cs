using UnityEngine;
using System.Collections;

public class towerBase : MonoBehaviour {

	public float health;
	public float max_Health;

	public float attack;
	public float defense;

	public float attack_rate; //this is time in seconds

	public string type;
	public int num;

	public bool upgradable;

	private GameObject gm;
	
	void Start () {
		gm = GameObject.Find("Game Manager");
	}

	public void upgrade(){
		Destroy(gameObject);

		ArrayList a = new ArrayList();
		a.Add(type);
		a.Add(num);
		a.Add(transform.position);
		a.Add(transform.rotation);

		gm.SendMessage("ally_upgrade", a);
	}

	public virtual void take_Damage(float amt){
		health = health - amt;

		if (health <= 0.0f) {
			health = 0.0f;
			Destroy(gameObject); //for right now we will just destroy the gameobject
		}
	}

	public void boost(float percent){
		attack = attack + (attack * percent);
		defense = defense + (defense * percent);
	}
}
