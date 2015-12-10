using UnityEngine;
using System.Collections;

public class BridgeScript : MonoBehaviour {
	//float time = 0f;
	bool _cooldown = false;
	// Use this for initialization
	void Start () {
		StartCoroutine(CheckDissapear());
	}
	
	// Update is called once per frame
	private IEnumerator CheckDissapear()
	{
		yield return new WaitForSeconds(3);
		if(Random.Range (0,10) > 5)
		{
			yield return new WaitForSeconds(Random.Range(10, 20));
			StartCoroutine(Dissapear());
		}
	}

	private IEnumerator Dissapear()
	{
		Transform[] Children = GetComponentsInChildren<Transform>();
		foreach (Transform child in Children)
			child.GetComponent<MeshRenderer>().material.color = Color.magenta;
		yield return new WaitForSeconds(20);
		foreach (Transform child in Children)
			child.transform.Translate(new Vector3(0, -500,0));
		yield return new WaitForSeconds(1);
		foreach (Transform child in Children)
		{
			child.transform.Translate(new Vector3(0, 500,0));
			child.GetComponent<MeshRenderer>().material.color = Color.white;
		}

		StartCoroutine(CheckDissapear());
	}
}
