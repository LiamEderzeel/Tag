using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	[SerializeField] protected int _controller = 0;
	[SerializeField] private float _angle;
	public float _score;
	[SerializeField] protected bool _tagged;
	public List<Player> players;
	[SerializeField] private Vector3 _startPos;
	protected GameManager gameManager;
	// Use this for initialization
	public virtual void Start () {
		_tagged = false;
		_startPos = this.transform.position;
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

	public void OnCollisionEnter(Collision Other)
	{
		if(Other.gameObject.tag == "KillBox")
			this.Reset();
	}
}
