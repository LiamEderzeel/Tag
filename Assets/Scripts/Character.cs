using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (MeshRenderer))]
[RequireComponent (typeof (MeshFilter))]
[RequireComponent (typeof (MeshCollider))]

public class Character : MonoBehaviour {

	//player basic movement & spawn


	#region variables
	//public:

	public float moveSpeed = 20.0f;
	public float turnSpeed = 10.0f;
	public Rigidbody rB;
	//private:
	private Vector2 m_Input;

	private Transform _transform;

	public bool isAssigned;


    #endregion

	private void Awake()
	{
		IsAssigned = false;
	}

	private void Start () 
	{
		_transform = this.GetComponent<Transform> ();

	}

	public bool IsAssigned
	{
		get {return isAssigned;}
		set {isAssigned = value;}
	}

	void FixedUpdate ()
	{

		Vector3 desiredMove = transform.forward*m_Input.y + transform.right*m_Input.x;
			
		transform.Translate(desiredMove * Time.deltaTime * moveSpeed);

	}

	public void AttachBody(GameObject prefab)
	{
		this.rB = prefab.GetComponent<Rigidbody> ();
	}
}