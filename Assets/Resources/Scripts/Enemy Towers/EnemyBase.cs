using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour {

	public float health;
	protected float max_health;

	protected float attack;
	protected float attack_rate;

	protected float defense;

	protected float rotation_rate;

	protected float speed;


	public void take_Damage(float amt){
		health = health - amt;
		
		if (health <= 0.0f) {
			health = 0.0f;
			Destroy(gameObject); //for right now we will just destroy the gameobject
		}
	}
}
