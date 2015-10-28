using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//public GameObject modelBig, modelFast, modelSmall, modelHand;

	public Character _Character = null;
	public int _Controller;
	private bool hasCharacter;
	private bool isHand;
	private Rigidbody rB;

	void Awake()
	{
		hasCharacter = false;
		isHand = false;
		_Controller = 0;
	}
	// Use this for initialization
	void Start () {
		//Character character;
		//character = Instantiate(this._Character,Vector3.zero,Quaternion.identity) as Character;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Character Character
	{
		get { return _Character;}
		set { _Character = value;}
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
