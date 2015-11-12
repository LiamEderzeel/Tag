using UnityEngine;
using System.Collections;

public class Hand : Player {

	public delegate void TagAction();
	public static event TagAction OnTag;
	// Use this for initialization

	public override void Start () {
		base.Start();
	}
	// Update is called once per frame
	public override void Update () {
		base.Update ();
	}

	public override void Ability1()
	{
		//Debug.Log("event arrived, controller = " + controller);
		Player closest = null;
		float closestsDist = 10;
		foreach (Player p in players)
		{
			float dist = Mathf.Sqrt (Mathf.Pow((p.transform.position.x - this.transform.position.x),2) + (Mathf.Pow((p.transform.position.z - this.transform.position.z),2)));
			if(dist <= closestsDist)
			{
				closestsDist = dist;
				closest = p;
			}
		}
		if(closest != null)
		{
			Vector3 tempPos = this.transform.position;
			int c1 = this.Controller;

			this._controller = closest.Controller;
			this.gameObject.GetComponent<InputHelper>().Controller = closest.Controller;

			closest.Controller = c1;
			closest.gameObject.GetComponent<InputHelper>().Controller = c1;

			this.transform.position = closest.transform.position;
			closest.transform.position = tempPos;

		}
	}

	public override void Reset()
	{
		base.Reset();
	}
}
