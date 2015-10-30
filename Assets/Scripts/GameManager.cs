using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private GameObject _tagger;
	public GameObject _player1;

	private void Awake ()
	{
		GlobalVars.GetSingleton ();
	}
    void Start ()
    {
		_player1 = GameObject.Find("Fast");
		_player1.GetComponent<Character>()._newTagger += newTagger;
    }

    void Update ()
    {
    }

	void newTagger( Character theTagger )
	{
		Debug.Log ("IT'S A TAGGER!");
    }
}
