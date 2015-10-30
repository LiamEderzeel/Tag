using UnityEngine;
using System.Collections;

public class Manhole : MonoBehaviour {

	public GameObject _holeA;
	public GameObject _holeB;
	[SerializeField] private bool _teleported;
	// Use this for initialization
	void Start () {
		_holeA = GameObject.FindGameObjectWithTag("Hole1a");
		_holeB = GameObject.FindGameObjectWithTag("Hole2a");
	}
	
	// Update is called once per frame
	void Update () {
    }

	void OnTriggerStay(Collider player){
		if(Input.GetKey(KeyCode.JoystickButton0)){
            switch (this.tag)
			{
			case ("Hole1a"):
                player.transform.position = _holeB.transform.position + new Vector3(0,10,0);
				break;
			case ("Hole2a"):
				player.transform.position = _holeA.transform.position + new Vector3(0,10,0);

				break;

			}       

        }
	}


	public bool Teleported
	{
		get{return _teleported;}
		set{_teleported = value;}
	}
}
