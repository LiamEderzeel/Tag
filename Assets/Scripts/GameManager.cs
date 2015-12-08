using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	[SerializeField] private List<int> _controllers;
	public List<float> _scores;
	public List<Player> _players;
	[SerializeField] private Slider[] _sliders = new Slider[4];
    [SerializeField] private MenuManager _menuManager;

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

	private void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _menuManager.SetEnd();
        }
		if (Input.GetKeyDown(KeyCode.Space))
		{
			foreach(Player p in _players)
				p.Reset();
			AssignController();
		}

		for(int i = 0; i < _scores.Count; ++i)
		{
			_sliders[i].value = _scores[i];
            if( _scores[i] >= 1)
            {
                _menuManager.SetEnd();
            }
		}
	}
}
