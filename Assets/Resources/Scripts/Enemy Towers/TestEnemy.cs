using UnityEngine;
using System.Collections;

public class TestEnemy : EnemyBase {

	public Transform target;

	private NavMeshAgent nav;

	void Start(){
		health = 100.0f;

		//this way we can grab it whenever we need to increase/decrease properties
		if (nav = GetComponent<NavMeshAgent> ()) {
			//nav = GetComponent<NavMeshAgent> ();

			nav.destination = target.position;
		}
	}
}
