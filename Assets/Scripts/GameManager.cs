using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	[SerializeField] private GameObject _tagger;
	public GameObject _player;
    private int _playerAmount = 4;
    private List<GameObject> _players = new List<GameObject>();

	private void Awake ()
	{
		GlobalVars.GetSingleton ();
        _player = Resources.Load("Prefabs/Player") as GameObject;
        for(int i = 1; i <= _playerAmount; ++i)
        {
           GameObject player = Instantiate(_player) as GameObject;
           player.gameObject.name = "Player " + i;
            _players.Add(player);
            Debug.Log("Player " + i);

        }
	}
    void Start ()
    {
		//_player1 = GameObject.Find("Player");
		//_player2 = GameObject.Find("Player2");
        for(int i = 1; i <= _players.Count; ++i)
        {
		_players[i].GetComponent<Player>()._newTagger += newTagger;
        }
    }

    void Update ()
    {
    }

	void newTagger( Player theTagger )
	{
		Debug.Log ("IT'S A TAGGER! " + theTagger.gameObject.name);
		_tagger = theTagger.gameObject;
		theTagger.Tag();
    }
}
