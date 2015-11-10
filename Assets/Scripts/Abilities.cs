using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Abilities : MonoBehaviour {

	[SerializeField] private List<GameObject> _players;
	[SerializeField] private CharacterType _characterType;
	// Use this for initialization
	void Awake () {
		_characterType = this.GetComponent<Player>().CharacterType;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FillPlayerList(List<GameObject> l)
	{
		for (int i = 0; i < l.Count;i++)
			_players.Add (l[i]);
		_players.Remove(this.gameObject);
	}


	public void Offensive()
	{
		if ((int)_characterType == 1)
		{
			foreach (GameObject p in _players)
			{
				if (Mathf.Sqrt (Mathf.Pow((p.transform.position.x - this.transform.position.x),2) + (Mathf.Pow((p.transform.position.z - this.transform.position.z),2))) <= 10)
					p.transform.position += new Vector3(0,10,0);
			}
		}
	}

	public CharacterType CharacterType
	{
		get {return _characterType;}
		set {_characterType = value;}
	}
}
