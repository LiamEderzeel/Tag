﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField] private int controller = 0;
	public bool Taged
	{
		set { _taged = value; }
	}
	[SerializeField] private bool _taged;
	[SerializeField] private bool _controlle = true;
	private float r_rot;
	private Vector2 m_Input;
	private Vector3 m_MoveDir = Vector3.zero;
	private CollisionFlags m_CollisionFlags;
	private Transform _transform;
	private Renderer _renderer;
	private string[] _horizontal  = {"Horizontal1", "Horizontal2", "Horizontal3", "Horizontal4"};
	private string[] _vertical  = {"Vertical1", "Vertical2", "Vertical3", "Vertical4"};
	[SerializeField] private Material[] _materials;
	private GameObject _player1;
	private float _angle;

	void Awake ()
	{
		_player1 = GameObject.Find("Fast");


	}
	void Start ()
	{
		_transform = GetComponent<Transform>();
		_renderer = GetComponent<Renderer>();

		if(_taged)
		{
			Tag();
		}
	}

	void Update ()
	{

	}

	void FixedUpdate ()
	{
		float speed = 20f;
		float rSpeed = 60f;
		if(_controlle)
		{
			GetInput();
			Vector3 desiredMove = new Vector3(m_Input.x, 0, m_Input.y);
			//Vector3 desiredMove = new Vector3(Camera.main.transform.position + Vector3(m_Input.x, 0, m_Input.y));
			this.gameObject.transform.eulerAngles = new Vector3(0, GlobalVars.MainCamera.transform.eulerAngles.y -90, 0);

			this.gameObject.transform.Translate(desiredMove * Time.deltaTime * speed);

			//this.gameObject.transform.Rotate(transform.up, r_rot * Time.deltaTime * rSpeed);
		}
		//Debug.Log (GlobalVars.MainCamera.transform.eulerAngles.normalized.y);
		//Quaternion rotation = new Quaternion(0, GlobalVars.MainCamera.transform.eulerAngles.y, 0, 0);
		//this.gameObject.transform.rotation = new Vector3( 0,GlobalVars.MainCamera.transform.eulerAngles.y,0);

	}

	void GetInput ()
	{
		float horizontal = Input.GetAxis(_horizontal[controller]);
		float vertical = Input.GetAxis(_vertical[controller]);
		float threhold =0.2f;

		if(horizontal < threhold && horizontal > -threhold){
			horizontal = 0f;
		}
		if(vertical < threhold && vertical > -threhold){
			vertical = 0f;
		}

		m_Input = new Vector2(-horizontal, -vertical);
		_angle = Mathf.Atan2(-horizontal, -vertical) * Mathf.Rad2Deg + GlobalVars.MainCamera.transform.eulerAngles.y - 180;
		Debug.Log(_angle);
		_player1.GetComponent<Character>()._angle = _angle;
		if (m_Input.sqrMagnitude > 1)
		{
			m_Input.Normalize();
		}

		//float rightH = Input.GetAxis("RightH");
		//if(rightH < threhold && rightH > -threhold){
		//	rightH = 0f;
		//}
		//else rightH = 1f;
		//r_rot = rightH;

	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Player"){
			if(_taged)
			{
				UnTag();
				//collision.gameObject.GetComponent<PlayerMovement>().Tag();
				Debug.Log("Tag your it!" + collision.gameObject.name);
			}
		}
	}

	public void Tag()
	{
		StartCoroutine(TagRoutine());
	}

	IEnumerator TagRoutine()
	{
		//_renderer.material = _materials[1];
		//_controlle = false;
		yield return new WaitForSeconds(2f);
		//_taged = true;
		//_controlle = true;
	}

	private void UnTag()
	{
		_renderer.material = _materials[0];
		_taged = false;
	}

}

