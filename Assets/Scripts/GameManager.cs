using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gamemanager : MonoBehaviour {
	[SerializeField] private List<int> _controllers;
	public List<Player> _players;

	// Use this for initialization
	void Start () {
		AssignController();
	}


	public void AssignController()
	{
		for (int j = 0; j < 4; j++)
			_controllers.Add (j);
		for (int i = 0; i < 4; i++)
		{
			int a = _controllers[Random.Range(0, _controllers.Count)];
		_players[i].Controller = a;
			_players[i].gameObject.GetComponent<InputHelper>().Controller = a;
			_controllers.Remove (a);
		}
	}

	public List<Player> Players
	{
		get{return _players;}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			foreach(Player p in _players)
				p.Reset();
			AssignController();
		}
	}
}
