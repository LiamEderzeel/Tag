using UnityEngine;
using System.Collections;

public delegate void Tagger(Player theTagger);

public class Player : MonoBehaviour
{
	[SerializeField] private bool _taged;
	public event Tagger _newTagger;
	private CollisionFlags m_CollisionFlags;
	private Transform _transform;
	private Renderer _renderer;
    private GameObject _character;

	public bool Taged
	{
		set { _taged = value; }
	}

	 private void Awake ()
	{
        GameObject character = Resources.Load("Prefabs/Character") as GameObject;
        _character = GameObject.Instantiate(character);
        _character.transform.parent = gameObject.transform;
		//_character = this.gameObject.transform.GetChild(0).gameObject;
		if(_taged)
		{
			_character.GetComponent<Character>().Taged = true;
		}
	}

	private void Start ()
	{
		_transform = GetComponent<Transform>();
		_renderer = GetComponent<Renderer>();

		if (_taged)
		{
			if(_newTagger != null)
			{
				_newTagger (this);
			}
		}
	}

	public void CharacterCollison(Character theCharacter)
	{
		Debug.Log (gameObject.name + _taged);
		if (_taged)
		{
			if(_newTagger != null)
			{
				_newTagger (theCharacter.gameObject.transform.parent.GetComponent<Player>());
				//theCharacter.gameObject.transform.parent.GetComponent<Player>().Tag();
				Debug.Log (theCharacter.gameObject.name);
				UnTag();
			}
		}
	}

	public void Tag ()
	{
		_taged = true;
        _character.GetComponent<Character>().Tag();
		Debug.Log(gameObject.name +  " set tagger " + _taged);
	}

	public void UnTag ()
	{
		_taged = false;
		_character.GetComponent<Character>().Taged = false;
		Debug.Log(gameObject.name +  " unset tagger " + _taged);
	}
}

