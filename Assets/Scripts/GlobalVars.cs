using UnityEngine;
using System.Collections;

public class GlobalVars : MonoBehaviour
{
	public static GlobalVars _singleton;
	public static GlobalVars GetSingleton()
	{
		if (_singleton == null) {
			GameObject g = new GameObject ("__EnemyManager");
			_singleton = g.AddComponent<GlobalVars> ();
		}
		return _singleton;
	}
	
    public static float RoundTime
    {
        get{ return _roundTime; }
    }
	private static float _roundTime;

	public static Camera MainCamera
	{
		get{ return _mainCamera; }
	}
	private static Camera _mainCamera;

	void Awake ()
	{
		_mainCamera = Camera.main;
	}
}
