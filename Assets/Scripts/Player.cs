using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//public GameObject modelBig, modelFast, modelSmall, modelHand;

	public Character _Character;
	public Mesh _CharacterMesh;
	public Material _CharacterMaterial;
	public Renderer _renderer;
	public int _Controller;
	private bool hasCharacter;
	private bool isHand;
	private Rigidbody rB;
	public MeshFilter _meshFilter;
	private MeshCollider _meshCollider;
	void Awake()
	{
		hasCharacter = false;
		isHand = false;
		_Controller = 0;
		this.gameObject.AddComponent<MeshRenderer>();
		this.gameObject.AddComponent<MeshFilter>();
		this.gameObject.AddComponent<MeshCollider>();
		this.gameObject.AddComponent<Renderer>();
		_renderer = this.gameObject.GetComponent<Renderer>();
		_meshFilter = this.gameObject.GetComponent<MeshFilter>();
		_meshCollider = this.gameObject.GetComponent<MeshCollider>();


	}
	// Use this for initialization
	void Start () {
		//Character character;
		//character = Instantiate(this._Character,Vector3.zero,Quaternion.identity) as Character;
		//this.gameObject.AddComponent(_Character.GetType());
		_renderer.material = _CharacterMaterial;
		_meshFilter.mesh = _CharacterMesh;
		_meshCollider.sharedMesh = _CharacterMesh;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Character Character
	{
		get { return _Character;}
		set { _Character = value;}
	}

	public Mesh CharacterMesh
	{
		set { _CharacterMesh = value;}
    }

	public bool HasCharacter
	{
		get {return hasCharacter;}
		set {hasCharacter = value;}
	}

	public bool IsHand
	{
		get{return isHand;}
		set{isHand = value;}
	}

	public void SetRB()
	{
		this.rB = _Character.GetComponent<Rigidbody>();
	}

}
