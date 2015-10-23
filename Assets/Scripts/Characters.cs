using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[RequireComponent (typeof (Rigidbody))]
public class Characters : MonoBehaviour {

	//player basic movement & spawn


	#region variables
	//public:
	public Hand hand;
	public Big big;
	public Fast fast;
	public Small small;


	public int totPlayers = 4;

	public float moveSpeed = 20.0f;
	public float turnSpeed = 10.0f;

	public List<GameObject> characterPrefabs;
	public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

	public List<int> players = new List<int>();
	public int chosenCharacter;

	//private:
	private Vector2 m_Input;

	private Transform _transform;

	private List<int> _chosenCharacters;
	private int _randomCharacter;

	private bool _charactersInstantiated = false;

	#endregion


	void Start () 
	{
		_transform = this.GetComponent<Transform>();

		_charactersInstantiated = false;
		//list of available characters
		for (int i = 0; i < 4; i++) 
		{
			players.Add (i);
			Debug.Log ("Available characters: " + i);
		}
	}



	void FixedUpdate ()
	{

		PlayerInput();
		AbilityInput ();
		SpawnInit ();

		Vector3 desiredMove = transform.forward*m_Input.y + transform.right*m_Input.x;
			
		transform.Translate(desiredMove * Time.deltaTime * moveSpeed);

	}

	#region Player Input
	public void PlayerInput()
	{
		float horizontal = Input.GetAxis ("Horizontal1");
		float vertical = Input.GetAxis ("Vertical1");
		float threhold = 0.2f;
		if (horizontal < threhold && horizontal > -threhold) {
			horizontal = 0f;
		}
		if (vertical < threhold && vertical > -threhold) {
			vertical = 0f;
		}

		m_Input = new Vector2 (horizontal, -vertical);
		
		if (m_Input.sqrMagnitude > 1) {
			m_Input.Normalize ();
		}
	}

	void AbilityInput()
	{
		
		//activate special ability
		if (Input.GetAxis ("Attack1") <= -1) {
			Debug.Log ("Attack avtivated");
			//ActivateAbility();
		}
		
		//activate defense ability
		if (Input.GetAxis ("Defense1") >= 1) {
			Debug.Log ("Defense activated");
			//ActivateDefense();
		}
	}


	void SpawnInit()
	{
		//instantiate all characters
		if (Input.GetKeyDown (KeyCode.Return) && !(_charactersInstantiated)) 
		{
			SpawnCharacters(totPlayers);
			_charactersInstantiated = true;
		}
	}
	#endregion
	

	#region Abilities
	public virtual void ActivateAbility()
	{
		Debug.Log ("Activate ability");
	}
	
	
	public virtual void ActivateDefense()
	{
		Debug.Log ("Activate defense");
	}
	#endregion


	#region Random Character Spawn
	public void SpawnCharacters(int numberToSpawn)
	{
		//list of chosen characters
		_chosenCharacters = new List<int> ();
		for (int i = 0; i < players.Count; i++) {
			_chosenCharacters.Add (i);
			Debug.Log ("Chosen characters: " + i);
		}

		for (int i = 0; i < numberToSpawn; i++) {
			//get random character from characters list
			_randomCharacter = Random.Range (0, _chosenCharacters.Count);
			Debug.Log ("Random character: " + _randomCharacter);

			//set chosen character
			chosenCharacter = players [_chosenCharacters [_randomCharacter]];
			Debug.Log ("Chosen character: " + chosenCharacter);

			//instantiate & spawn character prefabs
			if (chosenCharacter == 0) {
				//hand always spawns in centre
				Instantiate (characterPrefabs [0], spawnPoints [0].Position, Quaternion.identity);
			} else {	
					int b = Random.Range (1, spawnPoints.Count);
					//other characters spawn random in any other spawnpoint
					if (!spawnPoints[b].IsBezet)
					{
						Instantiate (characterPrefabs [chosenCharacter], spawnPoints [b].Position, Quaternion.identity);
						spawnPoints.RemoveAt(b);
					}
			}
			//remove last picked character from character list
			_chosenCharacters.RemoveAt (_randomCharacter);
		}
	}
	#endregion


}
