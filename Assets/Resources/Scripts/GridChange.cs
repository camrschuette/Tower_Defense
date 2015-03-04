using UnityEngine;
using System.Collections;

public class GridChange : MonoBehaviour {
	public Material good;
	public Material bad;
	public Material norm;

	void changeMat(string type){
		if (type == "good") {
				GetComponent<Renderer>().material = good;
		} else if (type == "bad") {
				GetComponent<Renderer>().material = bad;
		} else {
			GetComponent<Renderer>().material = norm;
		}
}
}
