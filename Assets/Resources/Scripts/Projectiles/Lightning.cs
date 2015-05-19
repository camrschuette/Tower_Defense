using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {

	private LineRenderer lineRenderer;
	public float maxZ = 8f;
	private int numOfSegments = 12;
	private Color colour = Color.white;
	private float PosRange = 1f;

	public Vector3 min;
	public Vector3 max;

	void Start () {

		Vector3 diff = max - min;

		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetVertexCount(numOfSegments);
		for(int i=1; i < numOfSegments-1; i++){

			float x = min.x + (((float)i/(float)(numOfSegments-1))*diff.x);
			x += Random.Range(PosRange,-PosRange);
			float y = min.y + (((float)i/(float)(numOfSegments-1))*diff.y);
			y += Random.Range(PosRange,-PosRange);
			float z = min.z + (((float)i/(float)(numOfSegments-1))*diff.z);

			lineRenderer.SetPosition(i, new Vector3(x,y,z));
		}
		lineRenderer.SetPosition(0, min);
		lineRenderer.SetPosition(numOfSegments-1, max);
	}
	
	void Update () {
		colour.a -= 10f*Time.deltaTime;

		lineRenderer.SetColors(colour,colour);
		if(colour.a <= 0f)
		{
			Destroy(this.gameObject);
		}
	}
}