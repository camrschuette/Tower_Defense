using UnityEngine;
using System.Collections;

public class TestEnemy : MonoBehaviour {

	public Transform target;
	
	// Update is called once per frame
	void Update () {
		//gameObject.transform.Translate (transform.right * 3.0f * Time.deltaTime);
		GetComponent<NavMeshAgent> ().destination = target.position;
	}
}
