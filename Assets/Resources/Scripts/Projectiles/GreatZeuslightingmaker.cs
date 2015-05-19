using UnityEngine;
using System.Collections;

public class GreatZeuslightingmaker : MonoBehaviour {

	public Lightning Lightningpref;

	public GameObject target;
	
	IEnumerator Start () {
		while(true){
			Lightningpref.GetComponent<Lightning> ().max = target.transform.position;
			Lightningpref.GetComponent<Lightning> ().min = transform.position;

			Instantiate(Lightningpref,this.transform.position, Quaternion.identity);
			//Instantiate(Lightningpref,this.transform.position, Quaternion.identity);

			if(target.tag == "Enemy"){
				target.gameObject.SendMessage("take_Damage", 0.1f);
			}
		
			yield return null;
		}
	}
}