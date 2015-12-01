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
		float closestsDist = 3;
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
			StartCoroutine (Freeze());
			closest.DoCoRoutine("Freeze");
			StartCoroutine (Tag (closest.transform));
		}
	}

	public override void Reset()
	{
		base.Reset();
	}
	IEnumerator Tag(Transform target)
	{			
        while(Vector3.Distance(transform.position,target.position) > 1f)
		{
			transform.LookAt(target);
			transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);
			yield return null;
		}
		int c1 = this.Controller;
		this._controller = closest.Controller;
		this.gameObject.GetComponent<InputHelper>().Controller = closest.Controller;
		
		closest.Controller = c1;
		closest.gameObject.GetComponent<InputHelper>().Controller = c1;
    }
	private IEnumerator Freeze ()
	{
		GetComponent<InputHelper>()._control = false;
		yield return new WaitForSeconds(40);
		GetComponent<InputHelper>()._control = true;
	}
}
