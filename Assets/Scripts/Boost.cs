using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour {
	private SpriteRenderer _spriteRenderer;
	private bool _colliderActive;
	// Use this for initialization
	void Start () {
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_colliderActive = true;
		_spriteRenderer.color = new Color(0,1,0);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name != "Tagger" && _colliderActive)
		{
			other.GetComponent<Runner>().DoCoRoutine("Boost");
			StartCoroutine(Inactive ());
		}
	}

	private IEnumerator Inactive()
	{
		_colliderActive = !_colliderActive;
		_spriteRenderer.color = new Color(1,0,0);
		yield return new WaitForSeconds(40);
		_colliderActive = !_colliderActive;
		_spriteRenderer.color = new Color(0,1,0);;
	}
}
