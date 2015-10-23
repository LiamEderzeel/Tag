using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	protected bool _isBezet;
	public Vector3 _position;

	void Start()
	{
		_isBezet = false;

	}
	public bool IsBezet
	{
		get { return _isBezet;}
		set { _isBezet = value;}
	}

	public Vector3 Position
	{
		get {return _position;}
	}
}
