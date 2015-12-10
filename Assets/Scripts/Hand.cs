using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hand : Player {
	
	private float _tagTimeStamp;
	private Runner closest = null;
	private RaycastHit hit;
    [SerializeField] private Image _cooldown;
    [SerializeField]
    private Canvas _canvas;
    private bool cooldown;
	[SerializeField] private AudioClip _tagClip;
	// Use this for initialization

	public override void Start () {
		base.Start();
	}
	// Update is called once per frame
	public override void Update () {
		base.Update ();
        PlayerNumber( );
        CooldownBar( _canvas );
        if( cooldown )
            _cooldown.transform.localScale += new Vector3((Time.deltaTime / 20), 0, 0 );

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

    protected void CooldownBar (Canvas c )
    {

        Vector3 v = Camera.main.transform.position - c.transform.position;

        v.x = v.z = 0.0f;

        c.transform.LookAt( Camera.main.transform.position - v );
        c.transform.rotation = ( Camera.main.transform.rotation );


    }
    public override void Ability1 ( )
    {

        GetComponent<Rigidbody>( ).AddForce( transform.right * 200 );
        GetComponent<Rigidbody>( ).AddForce( 0, 300, 0 );
        _cooldown.transform.localScale = new Vector3(0,1f,0);
        StartCoroutine(Cooldown(20));
    }

    private IEnumerator Cooldown(float s)
    {
        cooldown = !cooldown;
        yield return new WaitForSeconds( s );
        cooldown = !cooldown;
    }

	public override void Reset()
	{
		base.Reset();
	}
	void Tag(GameObject target)
	{
		AudioSource.PlayClipAtPoint(_tagClip, Camera.main.transform.position);
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
