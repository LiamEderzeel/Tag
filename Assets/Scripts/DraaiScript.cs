using UnityEngine;
using System.Collections;

public class DraaiScript : MonoBehaviour {

    [SerializeField]private float _turnSpeed;
    private int direction;
	// Use this for initialization
	void Start () {
        direction = Random.Range(1, 100);
        if( direction < 51 )
            direction = 1;
        else direction = -1;

	}
	// Update is called once per frame
	void FixedUpdate () {
	
        this.transform.Rotate(Vector3.up, 1f * _turnSpeed * Time.deltaTime * direction);
	}
}
