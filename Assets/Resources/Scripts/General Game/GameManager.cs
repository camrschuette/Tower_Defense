using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private Dictionary<string, Dictionary<string, Object>> allyTowers;
	private Dictionary<string, Object> enemyTowers;

	// Use this for initialization
	void Start () {
		allyTowers = new Dictionary<string, Dictionary<string, Object>> ();

		//initialize all of the starting towers
		allyTowers.Add ("turret", new Dictionary<string, Object>());
		allyTowers.Add ("directional", new Dictionary<string, Object>());
		allyTowers.Add ("hub", new Dictionary<string, Object>());
		allyTowers.Add ("flyer", new Dictionary<string, Object>());
		allyTowers.Add ("slow", new Dictionary<string, Object>());
		allyTowers.Add ("spikes", new Dictionary<string, Object>());

		/*for (int i=0; i < 3; i++){
			allyTowers["turret"].Add(i.ToString(), Resources.Load("Prefabs/Ally Towers/turret2"));
			allyTowers["directional"].Add(i.ToString(), Resources.Load("Prefabs/Ally Towers/directional4"));
		}*/

		//initialize all enemy towers (coming soon!)
		enemyTowers = new Dictionary<string, Object> ();

		//tempGO = Instantiate (allyTowers ["turret"], transform.position + new Vector3 (4.0f, 0.0f, 0.0f), transform.rotation) as GameObject;
		//tempGO = Instantiate (allyTowers ["turret"], transform.position + new Vector3 (12.0f, 0.0f, 0.0f), transform.rotation) as GameObject;
		//tempGO = Instantiate (allyTowers ["turret"], transform.position + new Vector3 (20.0f, 0.0f, 0.0f), transform.rotation) as GameObject;

	}

	public void ally_upgrade(ArrayList arr){
		string name = arr[0].ToString();
		int num = (int) arr[1] + 1;
		Vector3 pos = (Vector3) arr[2];
		Quaternion rot = (Quaternion) arr[3];

		GameObject tmp = Instantiate(allyTowers[name][num.ToString()], pos, rot) as GameObject;
	}

}
