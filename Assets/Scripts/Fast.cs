using UnityEngine;
using System.Collections;


public class Fast : Character{

	//additional mechanics & stats

	
	#region Variables
	//public:
	//private:
	#endregion
	
	
	void Start () 
	{
		moveSpeed *= 1.25f;
		turnSpeed *= 1.25f;
	}
	
	
	void Update () 
	{
	}

}
