using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum CharacterType {Hand=0, Fat=1, Fast=2, Small=3};
public delegate void Tagger( Character theTagger );

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterType _characterType;
    [SerializeField] private Mesh[] _meshList = new Mesh[4];
    private MeshFilter _meshFilter;
    [SerializeField] private bool _taged;
    public Tagger _newTagger;
	public float _angle;

    private void Awake ()
    {
        if(_taged)
        {        
            _characterType = CharacterType.Hand;
        }
        _meshFilter = this.gameObject.GetComponent<MeshFilter>();
        _meshFilter.mesh = _meshList[(int)_characterType];
    }
	private void Start()
	{
		if(!_taged)
		{
			_newTagger(this);
		}
	}

	private void Update()
	{
		this.gameObject.transform.eulerAngles = new Vector3(0, _angle, 0);
	}


}
