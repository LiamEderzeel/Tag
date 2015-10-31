using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum CharacterType {Hand=0, Fat=1, Fast=2, Small=3};


public class Character : MonoBehaviour
{
    [SerializeField] private CharacterType _characterType;
    [SerializeField] private Mesh[] _meshs = new Mesh[4];
	[SerializeField] private Material[] _materials = new Material[4];
    private MeshFilter _meshFilter;
    private bool _taged;

	public bool Taged
	{
		set { _taged = value; }
	}

	public float _angle;


    private void Awake ()
    {
        if(_taged)
        {        
            _characterType = CharacterType.Hand;
        }
        _meshFilter = this.gameObject.GetComponent<MeshFilter>();
		_meshFilter.mesh = _meshs[(int)_characterType];
    }
	
	private void Update()
	{
		this.gameObject.transform.eulerAngles = new Vector3(0, _angle, 0);
	}

	private void OnCollisionEnter (Collision collision) 
	{
		if(collision.gameObject.GetComponent<Character>() != null)
		{
			Player Player = collision.gameObject.transform.parent.GetComponent<Player>();
			if(_taged)
			{
			Debug.Log("Tag your it!" + Player.gameObject.name);
			}
		}
	}
}
