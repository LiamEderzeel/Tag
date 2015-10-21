using UnityEngine;
using System.Collections;

public class CameraTurner : MonoBehaviour {

	public int radius, height;
	public Vector3 lookAt;
	public double t;
	// Use this for initialization
	void Start () {
	
		this.transform.position = new Vector3 (0, height, radius * -1);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			if(t > 2*Mathf.PI)
				t = 0;
			Circle (t);
			t+= 0.01;
		}
	}

	void Circle(double t){
			transform.position = new Vector3(radius * Mathf.Cos((float)t), height , radius * Mathf.Sin((float)t));
			transform.LookAt(Vector3.zero);
		}
}
