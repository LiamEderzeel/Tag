using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	[SerializeField] protected int _controller = 0;
	[SerializeField] private float _angle;
	protected bool _frozen;
	public List<Player> players;
	[SerializeField] private Vector3 _startPos, _resetPos, _screenPos;
	protected GameManager gameManager;
	private float _timeStamp;
	private RaycastHit hit;

	// Use this for initialization
	public virtual void Start () {
		_frozen = false;
		_startPos = this.transform.position;
		_resetPos = _startPos;
		StartCoroutine(ResetPos());
		gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>() as GameManager;
	}
	
	// Update is called once per frame
	public virtual void Update () {
		this.gameObject.transform.eulerAngles = new Vector3(0,_angle,0);

	}

	public int Controller
	{
		get{return _controller;}
		set{_controller = value;}
	}

	public float Angle
	{
		get{return _angle;}
		set{_angle = value;}
	}
    

	public virtual void Ability1 ()
	{
		return;
	}

	public virtual void Reset()
	{
		this.transform.position = _startPos;
		this.GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

	private void SoftReset()
	{
		this.transform.position = _resetPos + new Vector3(0,1,0);
		this.GetComponent<Rigidbody>().velocity = Vector3.zero;
		if(this.tag != "Tagger")
			gameManager._scores[this.Controller] /= 2;
	}

	public void OnCollisionEnter(Collision Other)
	{
		if(Other.gameObject.tag == "KillBox")
		{
			this.SoftReset();
		}
	}

	private IEnumerator ResetPos()
	{
		if (Physics.Raycast(this.transform.position, -Vector3.up ,out hit, 5f))
			if(hit.collider.name != "KillBox")
				_resetPos = this.transform.position;
		Debug.DrawRay(_resetPos,new Vector3(0, 100, 0),Color.green,2,false);
		yield return new WaitForSeconds(2);
		yield return new WaitForFixedUpdate();
		StartCoroutine(ResetPos());
	}
}
