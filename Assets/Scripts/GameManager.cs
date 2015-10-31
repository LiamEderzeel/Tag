using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private GameObject _tagger;
	public GameObject _player1;
	public GameObject _player2;

	private void Awake ()
	{
		GlobalVars.GetSingleton ();
	}
    void Start ()
    {
		_player1 = GameObject.Find("Player");
		_player2 = GameObject.Find("Player2");
		_player1.GetComponent<Player>()._newTagger += newTagger;
		_player2.GetComponent<Player>()._newTagger += newTagger;
    }

    void Update ()
    {
    }

	void newTagger( Player theTagger )
	{
		Debug.Log ("IT'S A TAGGER!");
    }
}
