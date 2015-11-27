using UnityEngine;
using System.Collections;

public class Runner : Player {

	[SerializeField] private bool toggle, aPressed;
	public int explosionForce;
	// Use this for initialization
	public override void Start () {
		base.Start();
		toggle = false;
		aPressed = false;
	}
	// Update is called once per frame
	public override void Update () {
		base.Update();
		gameManager._scores[this.Controller] += 0.001f;
	}

	/*public override void Ability1()
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
	}*/

	/*public override void Ability1()
	{
		Debug.Log ("ability");
		foreach (Player p in players)
		{
			Debug.Log ("found player " + p);
			if (Mathf.Abs(Vector3.Distance(this.transform.position, p.transform.position)) <= 20)
			{
				p.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, this.transform.position, 20, 100);
			}
		}

	}*/

	public override void Reset()
	{
		base.Reset();
		this.GetComponent<MeshRenderer>().material.SetColor("_RimCol", Color.clear);
		toggle = false;
		aPressed = false;
	}
}
