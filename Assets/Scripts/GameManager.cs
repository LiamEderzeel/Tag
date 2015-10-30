using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private GameObject Tagger;
    void Start ()
    {

        GameObject g = Instantiate<GameObject>( Resources.Load<GameObject> ("Enemy2") );
        Character theEnemy = g.GetComponent<Enemy2> ();

        theEnemy.iDied += SomeEnemyDied;
    }

    void Update ()
    {
    }
}
