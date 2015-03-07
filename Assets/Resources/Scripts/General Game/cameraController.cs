using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

	public float speed = 2.0f;
	public float scrollSpeed = 1.0f;

	private float MIN_X = -20.0f;
	private float MIN_Y = -20.0f;
	private float MIN_Z = -20.0f;

	private float MAX_X = 20.0f;
	private float MAX_Y = 20.0f;
	private float MAX_Z = 20.0f;

	private float distance = 10.0f;

	private float xSpeed = 250.0f;
	private float ySpeed = 120.0f;
	
	private float yMinLimit = -20.0f;
	private float yMaxLimit = 80.0f;
	
	private float distanceMin = 3.0f;
	private float distanceMax = 15.0f;
	
	private float x = 0.0f;
	private float y = 0.0f;

	void Start(){
		Vector3 angles = transform.eulerAngles;
		x = angles.x;
		y = angles.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.D)){
			transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
		}

		if(Input.GetKey(KeyCode.A)){
			transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
		}

		if(Input.GetKey(KeyCode.S)){
			transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
		}

		if(Input.GetKey(KeyCode.W)){
			transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
		}

		//eventually going to switch back to alt keys
		if (Input.GetKey (KeyCode.B) || Input.GetKey (KeyCode.LeftAlt)) {

			//Zoom in and out
			transform.Translate(new Vector3(0,0, Input.GetAxis("Mouse ScrollWheel") * scrollSpeed));

			//rotating around
			if (Input.GetMouseButton(0)) {
				if (transform) {
					x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
					y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
					
					y = ClampAngle(y, yMinLimit, yMaxLimit);
					
					Quaternion rotation = Quaternion.Euler(y, x, 0.0f);

					transform.rotation = rotation;
				}
			}
		}

		check_boundaries ();
	}

	private void check_boundaries(){
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, MIN_X, MAX_X),
			Mathf.Clamp(transform.position.y, MIN_Y, MAX_Y),
			Mathf.Clamp(transform.position.z, MIN_Z, MAX_Z));
	}

	static private float ClampAngle (float angle, float min, float max) {
		if (angle < -360.0f)
			angle += 360.0f;
		if (angle > 360.0f)
			angle -= 360.0f;
		return Mathf.Clamp (angle, min, max);
	}
}
