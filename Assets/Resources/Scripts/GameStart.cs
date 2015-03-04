using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	public GameObject grid;
	public int mapWidth = 10;
	public int mapHeight = 10;

	private GameObject gameObjectToMove;

	void Start () {
		//Make the grid of cells to place the towers
			//??Put path in here??//
			//Make startNode and endNode for enemy waves
		print (transform.rotation);
		GameObject cell;

		for (int i = -1 * mapWidth/2; i < mapWidth/2; i++) {
			for (int j = 0; j < mapHeight/2; j++){
				cell = Instantiate (Resources.Load("Prefabs/GridCell"), new Vector3(grid.transform.position.x + j + 0.5f, grid.transform.position.y, grid.transform.position.z + i + 0.5f), new Quaternion(0.0f, 0.0f, 0.0f, 1.0f)) as GameObject;
				cell.transform.parent = grid.transform;
			}
		}

		for (int i = -1 * mapWidth/2; i < mapWidth/2; i++) {
			for (int j = -1; j >= -1 * mapHeight/2; j--){
				cell = Instantiate (Resources.Load("Prefabs/GridCell"), new Vector3(grid.transform.position.x + j + 0.5f, grid.transform.position.y, grid.transform.position.z + i + 0.5f), new Quaternion(0.0f, 0.0f, 0.0f, 1.0f)) as GameObject;
				cell.transform.parent = grid.transform;
			}
		}

	}
	
	void Update(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin, ray.direction * 1000.0f, Color.red, 5.0f);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 1000.0f)){
			hit.transform.gameObject.SendMessage("changeMat", "good");
		}
	}
}
	