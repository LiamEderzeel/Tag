using UnityEngine;
using System.Collections;

[RequireComponent (typeof (MeshFilter))]

public class Fast : Character{

	//additional mechanics & stats


	private void Awake ()
	{
		moveSpeed *= 1.25f;
		turnSpeed *= 1.25f;
	}
}