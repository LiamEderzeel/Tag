using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterType _characterType;
    [SerializeField] private Mesh[] _meshs = new Mesh[4];
	[SerializeField] private Material[] _materials = new Material[4];
    private MeshFilter _meshFilter;
    private Renderer _renderer;
	public float _angle;

    public CharacterType CharacterType
    {
        set { _characterType = value; }
    }

    private void Awake ()
    {
        _meshFilter = this.gameObject.GetComponent<MeshFilter>();
        _renderer = this.gameObject.GetComponent<Renderer>();
    }

    private void Start ()
    {
		_meshFilter.mesh = _meshs[(int)_characterType];
		_renderer.material = _materials[(int)_characterType];
    }

	private void Update()
	{
		this.gameObject.transform.eulerAngles = new Vector3(0, _angle, 0);
	}
	
	public void LoadModel (CharacterType characterType)
	{
		_characterType = characterType;
		_meshFilter.mesh = _meshs[(int)_characterType];
		_renderer.material = _materials[(int)_characterType];
	}

	private void OnCollisionEnter (Collision collision)
	{
		if(collision.gameObject.GetComponent<Character>() != null)
		{
			gameObject.transform.parent.GetComponent<Player>().CharacterCollison(collision.gameObject.GetComponent<Character>());
		}
	}
}
