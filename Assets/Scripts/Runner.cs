using UnityEngine;
using System.Collections;

public class Runner : Player {

	[SerializeField] private bool toggle, aPressed;
	// Use this for initialization
	public override void Start () {
		base.Start();
		toggle = false;
		aPressed = false;
	}
	// Update is called once per frame
	public override void Update () {
		base.Update();
	}

	public override void Ability1()
	{
		//Debug.Log("event arrived, controller = " + controller);
		this.transform.position += new Vector3(0,0.1f,0);
		if (!toggle && !aPressed)
		{
			this.GetComponent<MeshRenderer>().material.SetColor("_RimCol", Color.red);
			toggle = !toggle;
		}
		else if (toggle && !aPressed)
		{
			this.GetComponent<MeshRenderer>().material.SetColor("_RimCol", Color.clear);
			toggle = !toggle;
		}
	}

	public override void Reset()
	{
		base.Reset();
		this.GetComponent<MeshRenderer>().material.SetColor("_RimCol", Color.clear);
		toggle = false;
		aPressed = false;
	}
}
