using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class GameManager : MonoBehaviour {

	private Dictionary<string, Object> allyTowers;
	private Object gridCell;
	private GameObject tempGO;

	// Use this for initialization
	void Start () {
		allyTowers = new Dictionary<string, Object> ();

		//initialize all of the starting towers
		allyTowers.Add ("turret", Resources.Load ("Prefabs/Ally Towers/Double Barrel Turret"));

		//initialize all enemy towers (coming soon!)

		//initialize grid cell(s)

		//initialize map

		tempGO = Instantiate (allyTowers ["turret"], transform.position + new Vector3 (4.0f, 0.0f, 0.0f), transform.rotation) as GameObject;
		tempGO = Instantiate (allyTowers ["turret"], transform.position + new Vector3 (12.0f, 0.0f, 0.0f), transform.rotation) as GameObject;
		tempGO = Instantiate (allyTowers ["turret"], transform.position + new Vector3 (20.0f, 0.0f, 0.0f), transform.rotation) as GameObject;

	}
	

	void Update () {
	
	}

}
