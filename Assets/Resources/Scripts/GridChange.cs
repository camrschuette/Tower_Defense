using UnityEngine;
using System.Collections;

public class GridChange : MonoBehaviour {
	public Material good;
	public Material bad;
	public Material norm;

	void changeMat(string type){
		if (type == "good") {
				renderer.material = good;
		} else if (type == "bad") {
				renderer.material = bad;
		} else {
			renderer.material = norm;
		}
}
}
