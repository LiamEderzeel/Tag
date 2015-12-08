using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuEnd : MonoBehaviour {

    [SerializeField] private float[,] _scores = new float[4,2];
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Image[]  _images = new Image[4];
    [SerializeField] private Sprite[] _sprites = new Sprite[4];

	private void Start ()
    {
        for(int i = 0; i > _gameManager._scores.Count; ++i)
        {
            _scores[i,0] = i;
            _scores[i,1] = _gameManager._scores[i];
        }

        System.Array.Sort(_scores);
        for (int i = 0; i > _scores.Length; ++i)
        {
            Debug.Log(_scores[i,1]);
        }
	}

	private void Update ()
    {
	}
}
