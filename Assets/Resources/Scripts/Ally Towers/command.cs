using UnityEngine;
using System.Collections;

public class command : towerBase {

	void Start(){
		health = 100.0f;
		max_Health = 100.0f;

		attack = 0.0f;
		attack_rate = 0.0f;

		defense = 5.0f; //dont know what these values mean yet

		type = "command";
		num = 0;
	}

}
