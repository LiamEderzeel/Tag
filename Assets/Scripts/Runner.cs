using UnityEngine;
using System.Collections;

public class Runner : Player {

	[SerializeField] private bool blink, aPressed;
	public int explosionForce;
	// Use this for initialization
	public override void Start () {
		base.Start();
		blink = false;
	}
	// Update is called once per frame
	public override void Update () {
		if(!_frozen)
		{
			base.Update();
			if(!blink)
				gameManager._scores[this.Controller] += 0.001f;
		}
		if(blink && Time.time % 1 <= .50f)
			GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
		else if(blink && Time.time % 1 > .50f)
			GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
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
	}

	public void DoCoRoutine(string name)
	{
		StartCoroutine(name);
	}


	private IEnumerator Boost()
	{
		GetComponent<InputHelper>().MovementSpeed = 4;
		yield return new WaitForSeconds(6);
		GetComponent<InputHelper>().MovementSpeed = 2;
	}

	private IEnumerator Freeze ()
	{
		GetComponent<InputHelper>()._control = false;
		blink = true;
		Debug.Log ("freezing | " + Time.time);
		yield return new WaitForSeconds(10);
		GetComponent<InputHelper>()._control = true;
		Debug.Log ("unfrozen | " + Time.time);
		yield return new WaitForSeconds(10);
		blink = false;
		GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
	}
}
