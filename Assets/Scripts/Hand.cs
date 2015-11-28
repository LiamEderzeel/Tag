using UnityEngine;
using System.Collections;

public class Hand : Player {
	
	private float _tagTimeStamp;
	private Runner closest = null;
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
		float closestsDist = 5;
		foreach (Runner p in players)
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
			StartCoroutine (Tag (closest.transform));
		}
	}

	public override void Reset()
	{
		base.Reset();
	}

	IEnumerator Tag(Transform target)
	{

		GetComponent<InputHelper>()._control = false;
		foreach (Runner p in players)
			p.Freeze();
		
		int c1 = this.Controller;
		this._controller = closest.Controller;
		this.gameObject.GetComponent<InputHelper>().Controller = closest.Controller;
		
		closest.Controller = c1;
		closest.gameObject.GetComponent<InputHelper>().Controller = c1;

        while(Vector3.Distance(transform.position,target.position) > 1f)
		{
			transform.LookAt(target);
			transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);
			yield return null;
		}
		yield return new WaitForSeconds(4);
		GetComponent<InputHelper>()._control = true;
		//Reset ();
    }

	/*private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Runner-1" || col.gameObject.name == "Runner-2" || col.gameObject.name == "Runner-3" )
		{
			col.gameObject.GetComponent<Runner>().Tagged = true;
			_tagging = !_tagging;
			closest.Tagged = !closest.Tagged;

		}
	}*/
}
