using UnityEngine;
using System.Collections;

public class Runner : Player {

	// Use this for initialization
	public override void Start () {

		base.Start();
	}
	// Update is called once per frame
	public override void Update () {
		base.Update();
	}

	public override void Ability1()
	{
		//Debug.Log("event arrived, controller = " + controller);
		this.transform.position += new Vector3(0,0.1f,0);
	}

	public override void Reset()
	{
		base.Reset();
	}
}
