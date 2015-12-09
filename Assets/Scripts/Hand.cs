using UnityEngine;
using System.Collections;

public class Hand : Player {
	
	private float _tagTimeStamp;
	private Runner closest = null;
	private RaycastHit hit;
	// Use this for initialization

	public override void Start () {
		base.Start();
	}
	// Update is called once per frame
	public override void Update () {
		base.Update ();
        PlayerNumber( );
        float dot;
        Vector3 taggerToTarget, norm;
        if( !_frozen )
        foreach( Runner p in players )
        {
            taggerToTarget = ( p.transform.position - this.transform.position );
            norm = taggerToTarget.normalized;
            dot = Vector3.Dot( norm, this.transform.right );
            Debug.DrawRay( this.transform.position, taggerToTarget, Color.red );
            if( dot >= 0.6f && taggerToTarget.magnitude <= 3 )
            {
                StartCoroutine( Freeze( ) );
                p.DoCoRoutine( "Freeze" );
                Tag( p.gameObject);
                break;
            }
        }
	}

    public override void Ability1 ( )
    {

        GetComponent<Rigidbody>( ).AddForce( transform.right * 200 );
        GetComponent<Rigidbody>( ).AddForce( 0, 300, 0 );      
    }

	public override void Reset()
	{
		base.Reset();
	}
	void Tag(GameObject target)
	{
        Runner r = target.GetComponent<Runner>( );
		int c1 = this.Controller;
		this._controller = r.Controller;
		this.gameObject.GetComponent<InputHelper>().Controller = r.Controller;
		
		r.Controller = c1;
		r.gameObject.GetComponent<InputHelper>().Controller = c1;
    }
	private IEnumerator Freeze ()
	{
        _frozen = !_frozen;
		GetComponent<InputHelper>()._control = false;
		yield return new WaitForSeconds(20);
        _frozen = !_frozen;
		GetComponent<InputHelper>()._control = true;
	}
}
