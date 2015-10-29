using UnityEngine;
using System.Collections;

public class CharacterFactory : MonoBehaviour{
	
	public int numPlayers;
	public Player player;
	public Character[] characterList = new Character[4];
	public Mesh[] meshList = new Mesh[4];
	public Player[] players;
	public SpawnPoint[] spawnPoints = new SpawnPoint[5];
	
	void Awake ()
	{
		//Debug.Log ("Assigning Characters...");
		for (int i = 0; i < numPlayers; i++)
		{
			players[i] = Instantiate (player,Vector3.zero,Quaternion.identity) as Player;
		}
		AssignCharacters();
		//SpawnCharacters ();
	}

	protected void AssignCharacters()
	{
		int r = Random.Range(0,players.Length);
		players[r].Character = characterList[0];
		characterList[0].IsAssigned = true;
		players[r].HasCharacter = true;
		players[r].IsHand = true;
		//Debug.Log (r + " " +  players[r].HasCharacter);
		Debug.Log(players[r].Character = characterList[0]);
		for (int i = 0; i < numPlayers; i++)
        {
			Debug.Log (i);
			if (players[i].HasCharacter)
			{
				Debug.Log ("skipped " + i);
				continue;
			}

			int r2;
			do
			{
				r2 = Random.Range(1,characterList.Length);
			} while (characterList[r2].IsAssigned);

			
			players[i].Character = characterList[r2];
			players[i].CharacterMesh = meshList[r2];
			players[i].HasCharacter = true;
			characterList[r2].IsAssigned = true;
			//player[i].gameObject.GetComponent<Character>; 
			//Debug.Log ("Assigned Player " + i + " to " + characterList[r2]);
		}
	}
	


	protected void SpawnCharacters()
	{
		foreach (Player p in players)
		{
			p.SetRB();
			Debug.Log ("RB set");
			if (p.IsHand)
			{
				spawnPoints[0].IsBezet = true;
				p.transform.position = spawnPoints[0].Position;
			}
			else
			{
				for(int i = 0; i < spawnPoints.Length; i++)
				{
					int r;
					do
					{
						r = Random.Range(1, spawnPoints.Length);
					} while (spawnPoints[r].IsBezet);
					{
						spawnPoints[r].IsBezet = true;
						p.transform.position = spawnPoints[r].Position;
					}
				}

			}
		}
	}
	// Update is called once per frame
	void Update ()
	{
	
	}
}
